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
        public Contexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<FuncionariosComServicos> FuncionariosComServicos { get; set; }
    }
}
