using System.Web.Mvc;
using CashMachine.Security;

namespace CashMachine.Views
{
    public abstract class BaseViewPage : WebViewPage
    {
        public new virtual AuthorizationPrincipalModel User
        {
            get { return base.User as AuthorizationPrincipalModel; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public new virtual AuthorizationPrincipalModel User
        {
            get { return base.User as AuthorizationPrincipalModel; }
        }
    }
}