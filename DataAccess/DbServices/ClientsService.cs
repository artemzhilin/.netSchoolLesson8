using DataAccess.DbContext;
using DataAccess.Entities;

namespace DataAccess.DbServices
{
    public static class ClientsService
    {
        public static void CreateClient(ClientModel clientModel)
        {
            using (var dbContext = new BankContext())
            {
                dbContext.Clients.Add(clientModel);
                dbContext.SaveChanges();
            }
        }
    }
}