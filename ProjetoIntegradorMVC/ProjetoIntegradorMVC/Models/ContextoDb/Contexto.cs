using Microsoft.EntityFrameworkCore;
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
        public Contexto() 
        {
        }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjetoIntegrador;Trusted_Connection=true;");
        }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionariosComServicos> FuncionariosComServicos { get; set; }
    }
}
