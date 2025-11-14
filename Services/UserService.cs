using BankAPI.DTOs.User;
using BankAPI.Interfaces;
using BankAPI.Mappers;
using BankAPI.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public UserService(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        public async Task<NewUserDto?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                throw new Exception("Invalid credentials!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                throw new Exception("Invalid credentials!");

            return user.ToNewUserDto(_tokenService.CreateToken(user));
        }

        public async Task<NewUserDto?> RegisterAsync(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == registerUserDto.Email.ToLower());

            if (user != null)
                throw new Exception("Email already in use.");

            var appUser = registerUserDto.ToAppUserFromRegisterUserDto();

            var createdUser = await _userManager.CreateAsync(appUser, registerUserDto.Password);

            if (!createdUser.Succeeded)
                throw new Exception(string.Join(", ", createdUser.Errors.Select(e => e.Description)));

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

            if (!roleResult.Succeeded)
                throw new Exception("Failed to assign user role.");

            return appUser.ToNewUserDto(_tokenService.CreateToken(appUser));
        }
    }
}