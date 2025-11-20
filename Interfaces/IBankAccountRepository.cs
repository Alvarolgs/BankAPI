using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.DTOs.BankAccount;
using BankAPI.Helpers;
using BankAPI.Models;

namespace BankAPI.Interfaces
{
    public interface IBankAccountRepository
    {
        Task<BankAccount?> GetByUserIdAsync(string userId);
        Task<BankAccount> CreateAsync(BankAccount bankAccount);
        Task<BankAccount> UpdateAsync(BankAccount bankAccount);
        Task<BankAccount> DeleteAsync(BankAccount bankAccount);
    }
}