using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCorreiosApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class ClienteController : Controller
{

    private ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpPost]
    public  AdicionarCliente([FromBody] CreateClienteDto dto)
    {

    }

}
