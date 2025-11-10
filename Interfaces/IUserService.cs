using BankAPI.DTOs.User;

namespace BankAPI.Interfaces
{
    public interface IUserService
    {
        Task<NewUserDto?> RegisterAsync(RegisterUserDto registerUserDto);
        Task<NewUserDto?> LoginAsync(LoginDto loginDto);
    }
}