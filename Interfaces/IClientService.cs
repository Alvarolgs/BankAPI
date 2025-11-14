using BankAPI.DTOs.Client;
using BankAPI.Helpers;
using BankAPI.Models;

namespace BankAPI.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Result<Client>> GetById(int id);
        Task<Result<Client>> GetByEmail(string email);
        Task<Result<NewClientDto>> Create(RegisterClientDto registerClientDto);
        Task<Result<Client>> Update(int id, UpdateClientDto updateClientDto);
        Task<Result<Client>> Delete(int id);
    }
}