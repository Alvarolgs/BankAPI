using BankAPI.DTOs.BankAccount;
using BankAPI.DTOs.User;
using BankAPI.Models;

namespace BankAPI.Mappers
{
    public static class BankAccountMappers
    {
        public static BankAccountDto ToBankAccountDto(this BankAccount bankAccount)
        {
            return new BankAccountDto
            {
                InvoiceClosingDate = bankAccount.InvoiceClosingDate,
                InvoiceDueDate = bankAccount.InvoiceDueDate,
                Balance = bankAccount.Balance,
                AppUser = new AppUserDto
                {
                    FullName = bankAccount.AppUser.FullName,
                    Email = bankAccount.AppUser.Email
                }
            };
        }
        public static BankAccount ToBankAccountFromRegisterBankAccountDto(this RegisterBankAccountDto registerBankAccountDto, string appUserId)
        {
            return new BankAccount
            {
                InvoiceClosingDate = registerBankAccountDto.InvoiceClosingDate,
                InvoiceDueDate = registerBankAccountDto.InvoiceDueDate,
                AppUserId = appUserId
            };
        }
    }
}