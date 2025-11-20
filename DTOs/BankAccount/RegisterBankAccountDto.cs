using System.ComponentModel.DataAnnotations;

namespace BankAPI.DTOs.BankAccount
{
    public class RegisterBankAccountDto
    {
        [Required]
        [Range(1, 28, ErrorMessage = "InvoiceClosingDate must be between 1 and 28.")]
        public int InvoiceClosingDate { get; set; }
        [Required]
        [Range(1, 28, ErrorMessage = "InvoiceClosingDate must be between 1 and 28.")]
        public int InvoiceDueDate { get; set; }
    }
}