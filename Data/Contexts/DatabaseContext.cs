using Fiap.Web.RotaDaReciclagem.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.RotaDaReciclagem.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MoradorModel> Moradores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoradorModel>(entity =>
            {
                entity.ToTable("Moradores");
                entity.HasKey(e => e.MoradorId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Telefone).IsRequired().HasMaxLength(15);
                entity.Property(e => e.Senha).IsRequired();
                entity.Property(e => e.EnderecoBairro).IsRequired();
                entity.Property(e => e.Endereco).IsRequired();
                entity.Property(e => e.EnderecoNumero).IsRequired().HasColumnType("INTEGER");
                entity.Property(e => e.EnderecoComplemento).HasMaxLength(100);
            });

            modelBuilder.Entity<CaminhaoModel>(entity =>
            {
                entity.ToTable("Caminhoes");
                entity.HasKey(e => e.CaminhaoId);
                entity.Property(e => e.Motorista).IsRequired();
                entity.Property(e => e.Modelo).IsRequired();
                entity.Property(e => e.Placa).IsRequired();
                entity.Property(e => e.CapacidadeLitros).IsRequired();
            });
        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}