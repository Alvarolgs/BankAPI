using BankAPI.DTOs.BankAccount;
using BankAPI.Enums;
using BankAPI.Helpers;
using BankAPI.Interfaces;
using BankAPI.Mappers;
using BankAPI.Shared.Constants;

namespace BankAPI.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _bankAccountRepo;

        public BankAccountService(IBankAccountRepository bankAccountRepo)
        {
            _bankAccountRepo = bankAccountRepo;
        }

        public async Task<Result<BankAccountDto>> Create(RegisterBankAccountDto registerBankAccountDto, string appUserId)
        {
            var existingBankAccount = await _bankAccountRepo.GetByUserIdAsync(appUserId);

            if(existingBankAccount != null)
                return Result<BankAccountDto>.Failure(
                    new Error(
                        ErrorCodeEnum.AlreadyExists,
                        string.Format(ErrorMessages.AlreadyExistsMessage, EntityNames.BankAccount)
                    )
                );
            
            var bankAccount = await _bankAccountRepo.CreateAsync(registerBankAccountDto.ToBankAccountFromRegisterBankAccountDto(appUserId));

            return Result<BankAccountDto>.Success(bankAccount.ToBankAccountDto());
        }

        public async Task<Result<BankAccountDto>> Delete(string appUserId)
        {
            var bankAccount = await _bankAccountRepo.GetByUserIdAsync(appUserId);

            if(bankAccount == null)
                return Result<BankAccountDto>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.BankAccount)
                    )
                );

            var deletedBankAccount = await _bankAccountRepo.DeleteAsync(bankAccount);

            return Result<BankAccountDto>.Success(deletedBankAccount.ToBankAccountDto());
        }

        public async Task<Result<BankAccountDto>> GetByUserId(string appUserId)
        {
            var bankAccount = await _bankAccountRepo.GetByUserIdAsync(appUserId);

            if(bankAccount == null)
                return Result<BankAccountDto>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.BankAccount)
                    )
                );
            
            return Result<BankAccountDto>.Success(bankAccount.ToBankAccountDto());
        }

        public async Task<Result<BankAccountDto>> Update(string appUserId, UpdateBankAccountDto updateBankAccountDto)
        {
            var bankAccount = await _bankAccountRepo.GetByUserIdAsync(appUserId);

            if(bankAccount == null)
                return Result<BankAccountDto>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.BankAccount)
                    )
                );

            bankAccount.InvoiceClosingDate = updateBankAccountDto.InvoiceClosingDate;
            bankAccount.InvoiceDueDate = updateBankAccountDto.InvoiceDueDate;

            var updatedBankAccount = await _bankAccountRepo.UpdateAsync(bankAccount);

            return Result<BankAccountDto>.Success(updatedBankAccount.ToBankAccountDto());
        }
    }
}