using System.Linq;
using DataAccess.DbContext;

namespace CashMachine.Security
{
    public static class AuthorizationService
    {
        public static AuthorizationModel GetAuthorizationObject(string cardId)
        {
            AuthorizationModel authorizationModel = null;
            using (var dbContext = new BankContext())
            {
                authorizationModel = dbContext.Cards
                    .Where(c => c.CardId == cardId)
                    .Select(c => new AuthorizationModel()
                    {
                        CardId = c.CardId,
                        CardholderName = c.ClientModel.FirstName,
                        CardholderId =  c.ClientId
                    })
                    .SingleOrDefault();
            }
            return authorizationModel;
        }
    }
}