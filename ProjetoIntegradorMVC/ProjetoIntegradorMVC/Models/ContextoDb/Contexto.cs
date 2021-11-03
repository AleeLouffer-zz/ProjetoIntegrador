using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.ContextoDb
{
    public class Contexto : DbContext
    {
        public Contexto() { }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionariosComServicos> FuncionariosComServicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Empresa>().OwnsOne(
                   e => e.Endereco,
                   en =>
                   {
                       en.Property(p => p.Bairro).HasColumnName("Bairro");
                       en.Property(p => p.CEP).HasColumnName("CEP");
                       en.Property(p => p.Complemento).HasColumnName("Complemento");
                       en.Property(p => p.Localidade).HasColumnName("Localidade");
                       en.Property(p => p.Logradouro).HasColumnName("Logradouro");
                       en.Property(p => p.UF).HasColumnName("UF");
                   }
               );

            modelbuilder.Entity<FuncionariosComServicos>().HasOne(funcionariocomservico => funcionariocomservico.Funcionario).WithMany().OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<FuncionariosComServicos>().HasOne(funcionariocomservico => funcionariocomservico.Servico).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}   
