using System.ComponentModel.DataAnnotations;

namespace BankAPI.DTOs.Client
{
    public class NewClientDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}