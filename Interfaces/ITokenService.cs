using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models;

namespace BankAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}