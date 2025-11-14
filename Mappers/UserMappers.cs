using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.DTOs.User;
using BankAPI.Models;

namespace BankAPI.Mappers
{
    public static class UserMappers
    {
        public static NewUserDto ToNewUserDto(this AppUser appUserModel, string jwtToken)
        {
            return new NewUserDto
            {
                FullName = appUserModel.FullName,
                Email = appUserModel.Email,
                Token = jwtToken
            };
        }

        public static AppUser ToAppUserFromRegisterUserDto(this RegisterUserDto registerUserDto)
        {
            return new AppUser
            {
                FullName = registerUserDto.FullName,
                UserName = registerUserDto.Email,
                Email = registerUserDto.Email,
                BirthDate = registerUserDto.BirthDate
            };
        }
    }
}