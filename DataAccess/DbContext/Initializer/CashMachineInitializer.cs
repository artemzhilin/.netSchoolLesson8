using System.Collections.Generic;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.DbContext.Initializer
{
    public class CashMachineInitializer: CreateDatabaseIfNotExists<BankContext>
    {
        protected override void Seed(BankContext context)
        {
            context.Clients.Add(new ClientModel
            {
                FirstName = "Bankomat",
                LastName = "Terminalov",
                Cards = new List<CardModel>
                {
                    new CardModel
                    {
                        CardId = "0000000000000000",
                        PinCode = "0000",
                        Balance = 0
                    }
                }
            });
        }
    }
}