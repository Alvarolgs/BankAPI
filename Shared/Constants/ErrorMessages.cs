using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Shared.Constants
{
    public static class ErrorMessages
    {
        public const string AlreadyExistsMessage = "{0} already exists.";
        public const string NotFoundMessage = "{0} not found.";
        public const string InvalidCredentials = "Invalid {0} credentials.";
        public const string EmailInUse = "Email is already in use.";
        public const string UserRoleNotAssigned = "Failed to assign user role";
    }
}