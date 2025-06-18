using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Models;
using DesafioCorreiosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCorreiosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ClienteController : ControllerBase
{

    private ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarCliente([FromBody] CreateClienteDto dto)
    {
        Cliente cliente = await _clienteService.CadastraCliente(dto);

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
