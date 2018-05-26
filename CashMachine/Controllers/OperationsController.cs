using System;
using System.Web.Mvc;
using CashMachine.ViewModels.Operations;
using DataAccess.DbServices;

namespace CashMachine.Controllers
{
    [Authorize]
    public class OperationsController : BaseController
    {
        public ActionResult Index()
        {
            var operationsList = OperationsService.GetByCard(User.CardId);
            ViewData["operations"] = operationsList;
            return View();
        }
        
        [HttpGet]
        public ActionResult Withdraw()
        {
            var currentCardBalance = CardsService.GetBalance(User.CardId);
            ViewData["currentCardBalance"] = currentCardBalance;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(WithdrawViewModel withdrawViewModel)
        {
            if (ModelState.IsValid)
            {
                if (CardsService.HasEnoughMoney(User.CardId, Convert.ToDecimal(withdrawViewModel.Amount)))
                {
                    if (OperationsService.WithdrawMoney(User.CardId, Convert.ToDecimal(withdrawViewModel.Amount)))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Could not withdraw money. Try again");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Not enough money on the card balance");
                }
            }
            var currentCardBalance = CardsService.GetBalance(User.CardId);
            ViewData["currentCardBalance"] = currentCardBalance;
            return View();
        }

        
        [HttpGet]
        public ActionResult Recharge()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Recharge(RechargeViewModel rechargeViewModel)
        {
            if (ModelState.IsValid)
            {
                if (OperationsService.RechargeBalance(User.CardId, Convert.ToDecimal(rechargeViewModel.Amount)))
                {
                    return RedirectToAction("Index");                    
                }
                else
                {
                    ModelState.AddModelError("", "Could not recharge current card. Try again!");
                }
            }
            return View();
        }
        
    }
}