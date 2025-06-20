using DesafioCorreiosApi.Data;
using DesafioCorreiosApi.Models;
using DesafioCorreiosApi.Services.Interfaces;

namespace DesafioCorreiosApi.Services;

public class EnderecoService : IViaCep
{
    private readonly IViaCepIntegracao _viaCepIntegracao;
    private readonly CorreiosContext _context;

    public EnderecoService(IViaCepIntegracao viaCepIntegracao, CorreiosContext context)
    {
        _viaCepIntegracao = viaCepIntegracao;
        _context = context;
    }
    public async Task<Endereco> CadastraEndereco(string cep, string numero, string? complemento)
    {
        var resposta = await ObterEnderecoViaCepAsync(cep);

        var endereco = new Endereco()
        {
            Bairro = resposta.Bairro,
            Cep = resposta.Cep,
            Logradouro = resposta.Logradouro,
            Localidade = resposta.Localidade,
            Uf = resposta.Uf,
            Numero = numero,
            Complemento = complemento 
        };
        _context.Enderecos.Add(endereco);
        await _context.SaveChangesAsync();

        return endereco;

    }

    public async Task<Endereco> ObterEnderecoViaCepAsync(string cep)
    {
        var resposta = await _viaCepIntegracao.ObterEnderecoViaCepAsync(cep);

        if (resposta != null && resposta.IsSuccessStatusCode)
        {
            return resposta.Content;
        }

        return null;
    }


}