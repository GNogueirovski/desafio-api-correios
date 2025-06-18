using System.ComponentModel.DataAnnotations;

namespace DesafioCorreiosApi.Data.Dtos;

public class CreateClienteDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}
