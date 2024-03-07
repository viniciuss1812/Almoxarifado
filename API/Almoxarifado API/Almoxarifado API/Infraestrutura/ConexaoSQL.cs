using Almoxarifado_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Almoxarifado_API.Infraestrutura
{
    public class ConexaoSQL : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
           =>
             optionBuilder.UseSqlServer(
                 @"Server=.\SENAI;" +
                 "Database=dbAlmoxarifado;" +
                 "User id=sa;" +
        "Password=senai.123"

             );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaMotivo>()
                .HasMany(e => e.Motivos)
                .WithOne(e => e.CategoriaMotivo)
                .HasForeignKey(e => e.IDCategoriadoMotivo)
                .HasPrincipalKey(e => e.id);
        }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Funcionario>Funcionario{ get; set; } 
        public DbSet<CategoriaMotivo> Categoria { get; set; } 
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<CategoriaMotivo> CategoriaMotivo { get; set; }
        public DbSet<Motivo> Motivo { get; set; }

    }
}
