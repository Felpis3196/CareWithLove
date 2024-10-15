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
        public DbSet<User> Usuarios { get;set;}
        public DbSet<Avaliacao> Avaliacao { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuidador>().ToTable("Cuidador");
            modelBuilder.Entity<Dependente>().ToTable("Dependente");
            modelBuilder.Entity<ServicoCliente>().ToTable("ServicoClientes");
            modelBuilder.Entity<ServicoCuidador>().ToTable("ServicoCuidador");
            modelBuilder.Entity<User>().ToTable("Usuario");
            modelBuilder.Entity<Avaliacao>().ToTable("Avaliacao");

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cuidador)
                .WithOne(c => c.Usuario)
                .HasForeignKey<Cuidador>(c => c.UsuarioId)
                .IsRequired(false);
        }


    }
}
