using System.ComponentModel.DataAnnotations;

namespace BankAPI.DTOs.Client
{
    public class UpdateClientDto
    {
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string Phone { get; set; } = string.Empty;
    }
}