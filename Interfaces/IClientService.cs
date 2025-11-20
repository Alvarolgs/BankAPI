using BankAPI.DTOs.Client;
using BankAPI.Helpers;

namespace BankAPI.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAll();
        Task<Result<ClientDto>> GetById(int id);
        Task<Result<ClientDto>> GetByEmail(string email);
        Task<Result<NewClientDto>> Create(RegisterClientDto registerClientDto);
        Task<Result<ClientDto>> Update(int id, UpdateClientDto updateClientDto);
        Task<Result<ClientDto>> Delete(int id);
    }
}