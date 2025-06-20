using System.ComponentModel.DataAnnotations;

namespace DesafioCorreiosApi.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório")]
    public string Telefone { get; set; }

    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
}
