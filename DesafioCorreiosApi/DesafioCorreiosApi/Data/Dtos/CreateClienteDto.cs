namespace DesafioCorreiosApi.Data.Dtos;

public class CreateClienteDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cep { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
}
