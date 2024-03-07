using Bddgenerator.Data.Mappings;
using Bddgenerator.Model;
using Microsoft.EntityFrameworkCore;

namespace Bddgenerator.Data
{
    public class BddDataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Bddgenerator;User ID=sa;Password=1;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());
        }
    }
}
