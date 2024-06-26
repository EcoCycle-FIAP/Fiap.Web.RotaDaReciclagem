﻿using Fiap.Web.RotaDaReciclagem.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.RotaDaReciclagem.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MoradorModel> Moradores { get; set; }
        public DbSet<CaminhaoModel> Caminhoes { get; set; }
        public DbSet<AgendamentoModel> Agendamentos { get; set; }
        public DbSet<RotaModel> Rotas { get; set; }


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

            modelBuilder.Entity<AgendamentoModel>(entity =>
            {
                entity.ToTable("Agendamentos");
                entity.HasKey(e => e.AgendamentoId);
                entity.Property(e => e.Data).IsRequired().HasColumnType("DATE");
                entity.Property(e => e.TipoResiduo).IsRequired();
                entity.Property(e => e.QuantidadeLitros).IsRequired();
                entity.HasOne(e => e.Caminhao).WithMany(c => c.Agendamentos).HasForeignKey(e => e.CaminhaoId).IsRequired();
                entity.HasOne(e => e.Morador).WithMany(m => m.Agendamentos).HasForeignKey(e => e.MoradorId).IsRequired();
            });

            modelBuilder.Entity<RotaModel>(entity =>
            {
                entity.ToTable("Rotas");
                entity.HasKey(e => e.RotaId);
                entity.Property(e => e.PontosDeColeta).IsRequired();
                entity.Property(e => e.HorarioInicial).IsRequired().HasColumnType("DATE");
                entity.Property(e => e.HorarioFinal).IsRequired().HasColumnType("DATE");
                entity.HasOne(e => e.Caminhao).WithMany(c => c.Rotas).HasForeignKey(e => e.CaminhaoId);
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