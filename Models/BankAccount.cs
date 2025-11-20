namespace BankAPI.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public decimal Balance { get; set; } = 0;
        public int InvoiceClosingDate { get; set; }
        public int InvoiceDueDate { get; set; }
        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; }    
    }
}