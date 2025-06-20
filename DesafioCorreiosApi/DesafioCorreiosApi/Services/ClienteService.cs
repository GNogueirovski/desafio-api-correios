using AutoMapper;
using DesafioCorreiosApi.Data;
using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Models;
using DesafioCorreiosApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioCorreiosApi.Services;

public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly CorreiosContext _context;
    private readonly IViaCep _viaCep;

    public ClienteService(CorreiosContext context, IMapper mapper, IViaCep viaCep)
    {
        _context = context;
        _mapper = mapper;
        _viaCep = viaCep;
    }
    public async Task<ReadClienteDto> CadastraClienteAsync (CreateClienteDto dto)
    {

        var endereco = await _viaCep.CadastraEndereco(dto.Cep, dto.Numero, dto.Complemento);

        if (endereco == null)
        {
            return null;
        }

        var cliente = _mapper.Map<Cliente>(dto);
        cliente.EnderecoId = endereco.Id;
        cliente.Endereco = endereco;

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        var clienteDto = _mapper.Map<ReadClienteDto>(cliente);

        return clienteDto;
    }

    public async Task<ReadClienteDto> RecuperaClientePorIdAsync(int id)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Endereco)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
        {
            return null;
        }

        ReadClienteDto clienteDto = _mapper.Map<ReadClienteDto>(cliente);

        return clienteDto;
    }

}