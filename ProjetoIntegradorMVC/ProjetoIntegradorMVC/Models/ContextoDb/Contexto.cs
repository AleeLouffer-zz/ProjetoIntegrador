using Microsoft.EntityFrameworkCore;
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
        public Contexto() 
        {
        }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjetoIntegrador;Trusted_Connection=true;");
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PrestadorDeServico> PrestadoresDeServicos { get;set;}
        public DbSet<Agendamentos> Agendamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Favoritos> Favoritos { get; set; }
    }
}
