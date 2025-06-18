using DesafioCorreiosApi.Models;
using DesafioCorreiosApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCorreiosApi.Controllers;


[ApiController]
[Route("[controller]")]
public class ViaCepController: ControllerBase
{
    private readonly IViaCep _viaCep;

    public ViaCepController(IViaCep viaCep)
    {
        _viaCep = viaCep;
    }


    [HttpGet("{cep}")]
    public async Task<ActionResult<Endereco>> ListarDadosEndereco(string cep)
    {
        var resultado = await _viaCep.ObterEnderecoViaCep(cep);

        if (resultado == null)
        {
            return BadRequest("Cep não encontrado");
        }
        return Ok(resultado);
    }



}