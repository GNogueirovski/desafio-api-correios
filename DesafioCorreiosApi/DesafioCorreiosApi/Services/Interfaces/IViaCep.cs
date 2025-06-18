using DesafioCorreiosApi.Models;

namespace DesafioCorreiosApi.Services.Interfaces;

public interface IViaCep
{
    Task<Endereco> ObterEnderecoViaCep(string cep);
}