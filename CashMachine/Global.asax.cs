using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using CashMachine.Security;
using Newtonsoft.Json;

namespace CashMachine
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var deserializedModel = JsonConvert.DeserializeObject<AuthorizationModel>(authTicket.UserData);
                var newUser = new AuthorizationPrincipalModel(authTicket.Name)
                {
                    CardId = deserializedModel.CardId,
                    CardholderId = deserializedModel.CardholderId,
                    CardholderName = deserializedModel.CardholderName
                };
                HttpContext.Current.User = newUser;
            }
        }
    }
}
