using BankAPI.DTOs.Client;
using BankAPI.Models;

namespace BankAPI.Mappers
{
    public static class ClientMappers
    {
        public static NewClientDto ToNewClientDto(this Client client)
        {
            return new NewClientDto
            {
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone
            };
        }

        public static ClientDto ToClientDto(this Client client)
        {
            return new ClientDto
            {
                Name = client.Name,
                Email = client.Email,
                Phone = client.Phone
            };
        }
        public static Client ToClientFromRegisterClientDto(this RegisterClientDto registerClientDto)
        {
            return new Client
            {
                Name = registerClientDto.Name,
                Email = registerClientDto.Email,
                Phone = registerClientDto.Phone
            };
        }
    }
}