using System.ComponentModel.DataAnnotations;

namespace BankAPI.DTOs.User
{
    public class RegisterUserDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
    }
}