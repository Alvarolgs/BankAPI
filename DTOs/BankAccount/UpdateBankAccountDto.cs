using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.DTOs.BankAccount
{
    public class UpdateBankAccountDto
    {
        public int InvoiceClosingDate { get; set; }
        public int InvoiceDueDate { get; set; }
    }
}