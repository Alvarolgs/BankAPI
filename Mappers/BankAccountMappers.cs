using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.DTOs.BankAccount;
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
                Balance = bankAccount.Balance
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