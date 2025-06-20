using DesafioCorreiosApi.Models;

namespace DesafioCorreiosApi.Services.Interfaces;

public interface IViaCep
{
    Task<Endereco> ObterEnderecoViaCepAsync(string cep);
    Task<Endereco> CadastraEndereco(string cep, string numero, string? complemento);
}