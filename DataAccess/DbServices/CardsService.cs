using System.Linq;
using DataAccess.DbContext;

namespace DataAccess.DbServices
{
    public static class CardsService
    {
        public static bool CardExists(string cardNumber)
        {
            var cardExists = false;
            using (var dbContext = new BankContext())
            {
                cardExists = dbContext.Cards.Any(c => c.CardId == cardNumber);                
            }
            return cardExists;
        }

        public static bool CardExists(string cardNumber, string pinCode)
        {
            var cardExists = false;
            using (var dbContext = new BankContext())
            {
                cardExists = dbContext.Cards.Any(c => c.CardId == cardNumber && c.PinCode == pinCode);                
            }
            return cardExists;
        }

        public static bool HasEnoughMoney(string cardId, decimal amount)
        {
            bool result;
            using (var dbContext = new BankContext())
            {
                result = dbContext.Cards.Any(c => c.CardId == cardId && c.Balance >= amount);
            }
            return result;
        }

        public static decimal GetBalance(string cardId)
        {
            decimal balance;
            using (var dbContext = new BankContext())
            {
                balance = dbContext.Cards.Single(c => c.CardId == cardId).Balance;
            }

            return balance;
        }
    }
}