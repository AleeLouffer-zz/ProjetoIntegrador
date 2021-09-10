using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class Repositorio_Funcionario : IRepositorio_Funcionario
    {
        private readonly Contexto _contexto;

        public Repositorio_Funcionario(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<Funcionario> GetFuncionarios(List<int> Ids)
        {
            var funcionarios = new List<Funcionario>();

            foreach(var id in Ids)
            {
                funcionarios.Add(_contexto.Set<Funcionario>().Where(f => f.Id == id).SingleOrDefault());    
            }

            return funcionarios;
        }

        public void AddFuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) {
                if (VerificarFuncionarioExistente(funcionario)) throw new DuplicateNameException("O funcionário já existe");
                _contexto.Set<Funcionario>().Add(funcionario);
            }
            
            _contexto.SaveChanges();
        }

        public bool VerificarFuncionarioExistente(Funcionario funcionario)
        {
            var funcionariosDoBanco = _contexto.Set<Funcionario>().ToList();

            foreach (var funcionarioDoBanco in funcionariosDoBanco)
            {
                if (funcionarioDoBanco.CPF == funcionario.CPF) return true;
            }
            return false;
        }
    }
}
