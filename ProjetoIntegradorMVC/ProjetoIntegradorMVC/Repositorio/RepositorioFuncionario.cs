using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioFuncionario : IRepositorioFuncionario
    {
        private readonly Contexto _contexto;

        public RepositorioFuncionario(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool VerificarFuncionarioExistente(Funcionario funcionario) => BuscarFuncionarioPorCpf(funcionario.CPF) != null;

        private Funcionario BuscarFuncionarioPorCpf(string cpf) => _contexto.Set<Funcionario>().Where(funcionario => funcionario.CPF == cpf).SingleOrDefault();

        public List<Funcionario> BuscarFuncionariosPorIds(List<int> Ids)
        {
            var funcionarios = new List<Funcionario>();

            foreach(var id in Ids)
            {
                funcionarios.Add(_contexto.Set<Funcionario>().Where(funcionario => funcionario.Id == id).SingleOrDefault());    
            }

            return funcionarios;
        }

        public void AdicionarFuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) {
                if (VerificarFuncionarioExistente(funcionario)) throw new DuplicateNameException("O funcionário já existe");
                _contexto.Set<Funcionario>().Add(funcionario);
            }
            
            _contexto.SaveChanges();
        }
    }
}
