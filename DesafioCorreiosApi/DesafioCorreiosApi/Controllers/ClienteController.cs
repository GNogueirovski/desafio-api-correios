using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCorreiosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ClienteController : ControllerBase
{

    private IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public async Task<IActionResult> CriaCliente([FromBody] CreateClienteDto dto)
    {
        var cliente = await _clienteService.CadastraClienteAsync(dto);

        if (cliente == null)
        {
            return BadRequest("Não foi possível realizar o cadastro do cliente");
        }

        return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id }, cliente);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperaClientePorId(int id)
    {
        ReadClienteDto dto = await _clienteService.RecuperaClientePorIdAsync(id);

        if (dto == null)
        {
            return NotFound($"Cliente com o id {id} não foi encontrado");
        }

        return Ok(dto);

    }

}
