using DesafioCorreiosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioCorreiosApi.Data;

public class CorreiosContext : DbContext
{
    public CorreiosContext(DbContextOptions options) : base(options)
    {
    }
    DbSet<Cliente> Clientes { get; set; }

}
