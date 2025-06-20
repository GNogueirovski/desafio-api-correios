using DesafioCorreiosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioCorreiosApi.Data;

public class CorreiosContext : DbContext
{
    public CorreiosContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Cliente>()
            .HasOne(cliente => cliente.Endereco)
            .WithOne(endereco => endereco.Cliente)
            .HasForeignKey<Cliente>(cliente => cliente.EnderecoId);
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }


}
