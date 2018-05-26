using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using DataAccess.DbContext;
using DataAccess.Entities;

namespace DataAccess.DbServices
{
    public static class OperationsService
    {
        public const string ServiceCardId = "0000000000000000";
        
        public static bool RechargeBalance(string cardId, decimal amount)
        {
            var result = true;
            using (var dbContext = new BankContext())
            {
                try
                {
                    var serviceCard = dbContext.Cards.SingleOrDefault(c => c.CardId == ServiceCardId);
                    serviceCard.Balance -= amount;
                    var card = dbContext.Cards.SingleOrDefault(c => c.CardId == cardId);
                    card.Balance += amount;

                    var operation = new OperationModel
                    {
                        InId = cardId,
                        OutId = ServiceCardId,
                        Amount = amount,
                        InBalanceAfter = card.Balance,
                        OutBalanceAfter = serviceCard.Balance
                    };
                    dbContext.Operations.Add(operation);
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;
        }
        
        public static bool WithdrawMoney(string cardId, decimal amount)
        {
            var result = true;
            using (var dbContext = new BankContext())
            {
                try
                {
                    var serviceCard = dbContext.Cards.SingleOrDefault(c => c.CardId == ServiceCardId);
                    serviceCard.Balance += amount;
                    var card = dbContext.Cards.SingleOrDefault(c => c.CardId == cardId);
                    card.Balance -= amount;

                    var operation = new OperationModel
                    {
                        InId = ServiceCardId,
                        OutId = cardId,
                        Amount = amount,
                        InBalanceAfter = serviceCard.Balance,
                        OutBalanceAfter = card.Balance
                    };
                    dbContext.Operations.Add(operation);
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;
        }

        public static List<OperationModel> GetByCard(string cardId)
        {
            List<OperationModel> operations;
            using (var dbContext = new BankContext())
            {
                operations = dbContext.Operations.Where(o => o.OutId == cardId || o.InId == cardId).OrderByDescending(o => o.OperationId).ToList();
            } 
            return operations;
        }
    }
}