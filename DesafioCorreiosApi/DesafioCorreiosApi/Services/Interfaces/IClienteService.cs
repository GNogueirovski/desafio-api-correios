using DesafioCorreiosApi.Data.Dtos;

namespace DesafioCorreiosApi.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ReadClienteDto> CadastraClienteAsync(CreateClienteDto dto);
        Task<ReadClienteDto> RecuperaClientePorIdAsync(int id);

    }
}
