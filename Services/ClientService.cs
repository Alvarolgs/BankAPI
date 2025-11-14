using BankAPI.DTOs.Client;
using BankAPI.Enums;
using BankAPI.Helpers;
using BankAPI.Interfaces;
using BankAPI.Mappers;
using BankAPI.Models;
using BankAPI.Shared.Constants;

namespace BankAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepo;

        public ClientService(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task<Result<NewClientDto>> Create(RegisterClientDto registerClientDto)
        {
            var existingClient = await _clientRepo.GetByEmailAsync(registerClientDto.Email);

            if(existingClient != null)
                return Result<NewClientDto>.Failure(
                    new Error(
                        ErrorCodeEnum.AlreadyExists,
                        string.Format(ErrorMessages.AlreadyExistsMessage, EntityNames.Client)
                    )
                );

            var newClient = await _clientRepo.CreateAsync(registerClientDto.ToClientFromRegisterClientDto());
            
            return Result<NewClientDto>.Success(newClient.ToNewClientDto());  
        }

        public async Task<Result<Client>> Delete(int id)
        {
            var existingClient = await _clientRepo.GetByIdAsync(id);

            if(existingClient == null)
                return Result<Client>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.Client)
                    )
                );

            return Result<Client>.Success(await _clientRepo.DeleteAsync(existingClient));
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clientRepo.GetAllAsync();
        }

        public async Task<Result<Client>> GetByEmail(string email)
        {
            var client = await _clientRepo.GetByEmailAsync(email);

            if(client == null)
                return Result<Client>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.Client)
                    )
                );

            return Result<Client>.Success(client);
        }

        public async Task<Result<Client>> GetById(int id)
        {
            var client = await _clientRepo.GetByIdAsync(id);

            if(client == null)
                return Result<Client>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.Client)
                    )
                );

            return Result<Client>.Success(client);
        }

        public async Task<Result<Client>> Update(int id, UpdateClientDto updateClientDto)
        {
            var client = await _clientRepo.GetByEmailAsync(updateClientDto.Email);

            if(client == null)
                return Result<Client>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.Client)
                    )
                );

            client.Name = updateClientDto.Name;
            client.Email = updateClientDto.Email;
            client.Phone = updateClientDto.Phone;

            return Result<Client>.Success(await _clientRepo.UpdateAsync(client));
        }
    }
}