using AutoMapper;
using DesafioCorreiosApi.Data;
using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Models;

namespace DesafioCorreiosApi.Services;

public class ClienteService
{
    private readonly IMapper _mapper;
    private readonly CorreiosContext _context;

    public ClienteService(CorreiosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Cliente> CadastraCliente (CreateClienteDto dto)
    {
        Cliente cliente = _mapper.Map<Cliente>(dto);
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<ReadClienteDto> RecuperaClientePorIdAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return null;
        }

        ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);
        return clienteDto;
    }
}