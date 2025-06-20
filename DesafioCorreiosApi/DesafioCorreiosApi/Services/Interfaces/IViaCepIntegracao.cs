using DesafioCorreiosApi.Models;
using Refit;

namespace DesafioCorreiosApi.Services.Interfaces;

public interface IViaCepIntegracao
{

    [Get("/ws/{cep}/json")]
    Task<ApiResponse<Endereco>> ObterEnderecoViaCepAsync(string cep);


}