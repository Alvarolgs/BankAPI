using BankAPI.Data;
using BankAPI.DTOs.BankAccount;
using BankAPI.Helpers;
using BankAPI.Interfaces;
using BankAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly ApplicationDBContext _context;
        public BankAccountRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<BankAccount> CreateAsync(BankAccount bankAccount)
        {
            await _context.BankAccounts.AddAsync(bankAccount);
            await _context.SaveChangesAsync();

            return bankAccount;
        }

        public async Task<BankAccount> DeleteAsync(BankAccount bankAccount)
        {
            _context.BankAccounts.Remove(bankAccount);
            await _context.SaveChangesAsync();

            return bankAccount;
        }

        public async Task<BankAccount?> GetByUserIdAsync(string userId)
        {
            return await _context.BankAccounts.Include(b => b.AppUser).FirstOrDefaultAsync(b => b.AppUserId == userId);
        }

        public async Task<BankAccount> UpdateAsync(BankAccount bankAccount)
        {
            _context.BankAccounts.Update(bankAccount);
            
            await _context.SaveChangesAsync();

            return bankAccount;
        }
    }
}