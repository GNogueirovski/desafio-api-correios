using AutoMapper;
using DesafioCorreiosApi.Data;
using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCorreiosApi.Services;

public class ClienteService
{
    IMapper _mapper;
    CorreiosContext _context;

    public ClienteService(CorreiosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastraCliente (CreateClienteDto dto)
    {
        Cliente cliente = _mapper.Map<Cliente>(dto);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();


    }



}