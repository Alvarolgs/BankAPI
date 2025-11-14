using BankAPI.DTOs.User;
using BankAPI.Enums;
using BankAPI.Helpers;
using BankAPI.Interfaces;
using BankAPI.Mappers;
using BankAPI.Models;
using BankAPI.Shared.Constants;
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

        public async Task<Result<NewUserDto?>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null)
                return Result<NewUserDto?>.Failure(
                    new Error(
                        ErrorCodeEnum.InvalidCredentials,
                        string.Format(ErrorMessages.InvalidCredentials, EntityNames.User)
                    )
                );

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Result<NewUserDto?>.Failure(
                    new Error(
                        ErrorCodeEnum.InvalidCredentials,
                        string.Format(ErrorMessages.InvalidCredentials, EntityNames.User)
                    )
                );

            return Result<NewUserDto?>.Success(user.ToNewUserDto(_tokenService.CreateToken(user)));
        }

        public async Task<Result<NewUserDto?>> RegisterAsync(RegisterUserDto registerUserDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == registerUserDto.Email.ToLower());

            if (user != null)
                return Result<NewUserDto?>.Failure(
                    new Error(
                        ErrorCodeEnum.InvalidCredentials,
                        ErrorMessages.EmailInUse
                    )
                );

            var appUser = registerUserDto.ToAppUserFromRegisterUserDto();

            var createdUser = await _userManager.CreateAsync(appUser, registerUserDto.Password);

            if (!createdUser.Succeeded)
                return Result<NewUserDto?>.Failure(
                        new Error(
                            ErrorCodeEnum.UnexpectedError,
                            string.Join(", ", createdUser.Errors.Select(e => e.Description))
                        )
                    );

            var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

            if (!roleResult.Succeeded)
                return Result<NewUserDto?>.Failure(
                        new Error(
                            ErrorCodeEnum.RegisterError,
                            ErrorMessages.UserRoleNotAssigned
                        )
                    );

            return Result<NewUserDto?>.Success(appUser.ToNewUserDto(_tokenService.CreateToken(appUser)));
        }
    }
}