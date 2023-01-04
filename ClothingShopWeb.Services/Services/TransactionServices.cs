using ClothingShopWeb.Data.DBContext;
using ClothingShopWeb.Data.Entities;
using ClothingShopWeb.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShopWeb.Services.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly DB_Context _context;
        public TransactionServices(DB_Context context)
        {
            _context = context;
        }

        public async Task<bool> CreateTransaction(TransactionModel data)
        { 
            bool result = false;
            try
            {
                Transaction transaction = new Transaction();
                if (data!=null)
                {
                    transaction.Id = Guid.NewGuid();
                    transaction.UserId = data.UserId;
                    transaction.Users = data.Users;
                    transaction.TotalPrice = data.TotalPrice;
                    transaction.Message = data.Message;
                    transaction.Status = data.Status;
                    transaction.CreateBy = data.CreateBy;
                    transaction.UpdateBy = data.UpdateBy;
                    transaction.CreateDate = data.CreateDate;
                    transaction.UpdateDate = data.UpdateDate;
                    await _context.Transactions.AddAsync(transaction);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteTransaction(Guid id)
        {
            bool result = false;
            try
            {
                var transaction =await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
                if (transaction!=null)
                {
                    var lstCart = await _context.Carts.Where(x=>x.TransactionId == transaction.Id).ToListAsync();
                    if (lstCart!=null&& lstCart.Count>0)
                    {
                        _context.Carts.RemoveRange(lstCart);
                    }
                    _context.Transactions.Remove(transaction);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> UpdateTransaction(Guid id,TransactionModel data)
        {
            bool result = false;
            try
            {
                var transaction =await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
                if (transaction!=null)
                {
                    transaction.UserId = data.UserId;
                    transaction.Users = data.Users;
                    transaction.TotalPrice = data.TotalPrice;
                    transaction.Message = data.Message;
                    transaction.Status = data.Status;
                    transaction.UpdateBy = data.UpdateBy;
                    transaction.UpdateDate = data.UpdateDate;
                    _context.Transactions.Update(transaction);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<List<Transaction>> ViewListTransaction()
        {
            List <Transaction> result = new List<Transaction>();
            try
            {
                result = await _context.Transactions.ToListAsync();
            }
            catch (Exception)
            {
                result = null;
            }
            return result;
        }
    }
}
