using ClothingShopWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.IServices
{
    public interface ITransactionServices
    {
        public Task<bool> CreateTransaction(TransactionModel data);
        public Task<bool> UpdateTransaction(Guid id,TransactionModel data);
        public Task<bool> DeleteTransaction(Guid id);
        public Task<List<Transaction>> ViewListTransaction();
    }
}
