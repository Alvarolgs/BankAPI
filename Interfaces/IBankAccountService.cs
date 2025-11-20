using BankAPI.DTOs.BankAccount;
using BankAPI.Helpers;
using BankAPI.Models;

namespace BankAPI.Interfaces
{
    public interface IBankAccountService
    {
        Task<Result<BankAccountDto>> GetByUserId(string appUserId);
        Task<Result<BankAccountDto>> Create(RegisterBankAccountDto registerBankAccountDto, string appUserId);
        Task<Result<BankAccountDto>> Update(string appUserId, UpdateBankAccountDto updateClientDto);
        Task<Result<BankAccountDto>> Delete(string appUserId);
    }
}