﻿namespace DesafioCorreiosApi.Data.Dtos;

public class ReadClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
}
