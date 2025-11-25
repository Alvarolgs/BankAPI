using BankAPI.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace BankAPI.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}