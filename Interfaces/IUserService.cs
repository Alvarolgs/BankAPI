using BankAPI.DTOs.User;
using BankAPI.Helpers;

namespace BankAPI.Interfaces
{
    public interface IUserService
    {
        Task<Result<NewUserDto?>> RegisterAsync(RegisterUserDto registerUserDto);
        Task<Result<NewUserDto?>> LoginAsync(LoginDto loginDto);
    }
}