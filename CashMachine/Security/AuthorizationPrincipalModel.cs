using System.Security.Principal;

namespace CashMachine.Security
{
    public class AuthorizationPrincipalModel : AuthorizationModel, IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }
        public AuthorizationPrincipalModel(string cardId)
        {
            this.Identity = new GenericIdentity(cardId);
        }
    }
}