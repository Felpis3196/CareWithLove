using CareWithLoveApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CareWithLoveApp.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public DbSet<Cuidador> Cuidadores { get; set;}
        public DbSet<Dependente> Dependentes { get; set;}
        public DbSet<ServicoCliente> ServicoClientes { get; set;}
        public DbSet<ServicoCuidador> ServicoCuidadores { get; set;}
        public DbSet<Usuario> Usuarios { get;set;}
        public DbSet<Avaliacao> Avaliacao { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuidador>().ToTable("tbCuidador");
            modelBuilder.Entity<Dependente>().ToTable("tbDependente");
            modelBuilder.Entity<ServicoCliente>().ToTable("tbServicoClientes");
            modelBuilder.Entity<ServicoCuidador>().ToTable("tbServicoCuidador");
            modelBuilder.Entity<Usuario>().ToTable("tbUsuario");
            modelBuilder.Entity<Avaliacao>().ToTable("tbAvaliacao");
        }
    }
}
