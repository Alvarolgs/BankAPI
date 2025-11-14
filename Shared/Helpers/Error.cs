using BankAPI.Enums;

namespace BankAPI.Helpers
{
    public record Error (ErrorCodeEnum code, string description)
    {
        public static Error None => new (ErrorCodeEnum.None, string.Empty);
    }
}