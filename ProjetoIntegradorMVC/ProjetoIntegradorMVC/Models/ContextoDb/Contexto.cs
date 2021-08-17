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
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PrestadorDeServico> PrestadoresDeServicos { get;set;}
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}
