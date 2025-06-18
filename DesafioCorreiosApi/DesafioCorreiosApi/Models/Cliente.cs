using System.ComponentModel.DataAnnotations;

namespace DesafioCorreiosApi.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Telefone { get; set; }
}
