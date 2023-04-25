using ExemploEntityFramework01.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExemploEntityFramework01.DB
{
    public class ContextoDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=banco_teste;User Id=postgres;Password=root;");
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }                

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Endereco>();

            modelBuilder.Entity<Pessoa>()
                        .HasOne(p => p.Endereco)
                        .WithOne()
                        .HasForeignKey<Pessoa>(p => p.EnderecoId);
        }
    }
}
