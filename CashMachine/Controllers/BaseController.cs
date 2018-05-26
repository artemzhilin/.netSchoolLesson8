using System.Web.Mvc;
using CashMachine.Security;

namespace CashMachine.Controllers
{
    public class BaseController : Controller
    {
        protected new virtual AuthorizationPrincipalModel User
        {
            get { return HttpContext.User as AuthorizationPrincipalModel; }
        }
    }
}