using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioFuncionario : BaseRepositorio<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(Contexto contexto) : base(contexto) { }

        public Funcionario BuscarFuncionarioPorCpf(string cpf) => _contexto.Set<Funcionario>().Where(funcionario => funcionario.CPF == cpf).SingleOrDefault();

        public List<Funcionario> BuscarFuncionariosPorIds(List<int> Ids)
        {
            var funcionarios = new List<Funcionario>();

            foreach(var id in Ids)
            {
                var funcionario = BuscarPorID(id);    
                funcionarios.Add(funcionario);    
            }

            return funcionarios;
        }

        public void AdicionarFuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) Adicionar(funcionario); 
            
            _contexto.SaveChanges();
        }

        public override List<Funcionario> ObterTodos()
        {
            return _contexto.Funcionarios
                .Include(funcionario => funcionario.Agendamentos)
                .Include(funcionario => funcionario.Empresa)
                .Include(funcionario => funcionario.ExpedientesDeTrabalho)
                .AsNoTracking().ToList();
        }

        public Funcionario BuscarPorID(int id)
        {
            return ObterTodos().SingleOrDefault(funcionario => funcionario.Id == id);
        }
    }
}
