using BankAPI.Models;

namespace BankAPI.DTOs.BankAccount
{
    public class BankAccountDto
    {
        public decimal Balance { get; set; } = 0;
        public int InvoiceClosingDate { get; set; }
        public int InvoiceDueDate { get; set; }
        // public AppUser? AppUser{get; set;}
    }
}