using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccess.DbServices;
using CashMachine.ViewModels.Accounts;
using Newtonsoft.Json;
using CashMachine.Security;

namespace CashMachine.Controllers
{
    public class AccountsController : BaseController
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (TempData["statusRegistration"] != null)
            {
                ViewBag.StatusRegistration = TempData["statusRegistration"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (CardsService.CardExists(loginViewModel.CardID, loginViewModel.PinCode))
                {
                    var authorizationObject = AuthorizationService.GetAuthorizationObject(loginViewModel.CardID);
                    var authorizationObjectSerialized = JsonConvert.SerializeObject(authorizationObject);
                    FormsAuthentication.SetAuthCookie(authorizationObject.CardId, false); 
                    var authTicket = new FormsAuthenticationTicket(1, authorizationObject.CardId, DateTime.Now,
                        DateTime.Now.AddMinutes(20),
                        false, authorizationObjectSerialized);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid card number or pin code");
            return View(loginViewModel);
        }
        
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            string messageRegistration = string.Empty; 
            if (ModelState.IsValid)
            {
                if (!CardsService.CardExists(registrationViewModel.CardID))
                {
                    ClientsService.CreateClient(registrationViewModel.ConvertToClient());
                    TempData["statusRegistration"] = true;
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Card already exists");
                }
            }
            else
            {
                ModelState.AddModelError("", "Something wrong");
            }
            ViewBag.Message = messageRegistration;
            return View(registrationViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}