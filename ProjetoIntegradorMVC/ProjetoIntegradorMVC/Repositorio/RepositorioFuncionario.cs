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

        public List<Funcionario> BuscarFuncionariosPorIds(List<int> Ids)
        {
            var funcionarios = new List<Funcionario>();

            foreach(var id in Ids)
            {
                funcionarios.Add(_contexto.Set<Funcionario>().Where(funcionario => funcionario.Id == id).SingleOrDefault());    
            }

            return funcionarios;
        }

        public void Adicionarfuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) {
                if (VerificarFuncionarioExistente(funcionario)) throw new DuplicateNameException("O funcionário já existe");
                _contexto.Set<Funcionario>().Add(funcionario);
            }
            
            _contexto.SaveChanges();
        }

        public bool VerificarFuncionarioExistente(Funcionario funcionario)
        {
            return BuscarFuncionarioPorCpf(funcionario.CPF) != null;
        }

        public Funcionario BuscarFuncionarioPorCpf(string cpf)
        {
            return _contexto.Set<Funcionario>().Where(funcionario => funcionario.CPF == cpf).SingleOrDefault();
        }
    }
}
