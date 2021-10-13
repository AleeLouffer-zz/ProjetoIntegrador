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
                var funcionario = BuscarPorId(id);    
                funcionarios.Add(funcionario);    
            }

            return funcionarios;
        }

        public void AdicionarFuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) Adicionar(funcionario);
        }
    }
}
