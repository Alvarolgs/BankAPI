using BankAPI.DTOs.Client;
using BankAPI.Enums;
using BankAPI.Helpers;
using BankAPI.Interfaces;
using BankAPI.Mappers;
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

        public async Task<Result<ClientDto>> Delete(int id)
        {
            var existingClient = await _clientRepo.GetByIdAsync(id);

            if(existingClient == null)
                return Result<ClientDto>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.Client)
                    )
                );

            var clientDeleted = await _clientRepo.DeleteAsync(existingClient);

            return Result<ClientDto>.Success(clientDeleted.ToClientDto());
        }

        public async Task<List<ClientDto>> GetAll()
        {
            var clientList = await _clientRepo.GetAllAsync();

            return clientList.Select(c => c.ToClientDto()).ToList();
        }

        public async Task<Result<ClientDto>> GetByEmail(string email)
        {
            throw new Exception();
        }

        public async Task<Result<ClientDto>> GetById(int id)
        {
            var client = await _clientRepo.GetByIdAsync(id);

            if(client == null)
                return Result<ClientDto>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.Client)
                    )
                );

            return Result<ClientDto>.Success(client.ToClientDto());
        }

        public async Task<Result<ClientDto>> Update(int id, UpdateClientDto updateClientDto)
        {
            var client = await _clientRepo.GetByIdAsync(id);

            if(client == null)
                return Result<ClientDto>.Failure(
                    new Error(
                        ErrorCodeEnum.NotFound,
                        string.Format(ErrorMessages.NotFoundMessage, EntityNames.Client)
                    )
                );

            client.Name = updateClientDto.Name;
            client.Email = updateClientDto.Email;
            client.Phone = updateClientDto.Phone;

            var updatedClient = await _clientRepo.UpdateAsync(client);

            return Result<ClientDto>.Success(updatedClient.ToClientDto());
        }
    }
}