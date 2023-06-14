using Controle_Contatos.Models;
using Microsoft.EntityFrameworkCore;

namespace controle_contatos.Data
{
    public class ContatoDbContext : DbContext
    {
        public ContatoDbContext(DbContextOptions<ContatoDbContext> op) : base(op)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

    }
}

