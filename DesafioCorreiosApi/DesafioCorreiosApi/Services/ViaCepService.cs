using DesafioCorreiosApi.Models;
using DesafioCorreiosApi.Services.Interfaces;

namespace DesafioCorreiosApi.Services;

public class ViaCepService : IViaCep
{
    private readonly IViaCepIntegracao _viaCepIntegracao;

    public ViaCepService(IViaCepIntegracao viaCepIntegracao)
    {
        _viaCepIntegracao = viaCepIntegracao;
    }

    public async Task<Endereco> ObterEnderecoViaCep(string cep)
    {
        var resposta = await _viaCepIntegracao.ObterEnderecoViaCep(cep);

        if (resposta != null && resposta.IsSuccessStatusCode)
        {
            return resposta.Content;
        }

        return null;

    }
}