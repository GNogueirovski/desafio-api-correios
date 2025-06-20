﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioCorreiosApi.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; } 
    public string Uf { get; set; }

    public Cliente Cliente { get; set; }
}