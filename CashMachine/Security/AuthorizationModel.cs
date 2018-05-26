using System.Security.Principal;

namespace CashMachine.Security
{
    public class AuthorizationModel
    {
        public string CardId { get; set; }
        public int CardholderId { get; set; }
        public string CardholderName { get; set; }
        public AuthorizationModel() {}
    }
}