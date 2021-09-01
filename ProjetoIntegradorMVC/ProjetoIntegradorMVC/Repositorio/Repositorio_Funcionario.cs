using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
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

        public List<Funcionario> GetFuncionario(List<int> Ids)
        {
            var funcionarios = new List<Funcionario>();

            foreach(var id in Ids)
            {
                funcionarios.Add(_contexto.Set<Funcionario>().Where(f => f.Id == id).SingleOrDefault());    
            }

            return funcionarios;
        }

        public void SaveFuncioarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) {
                _contexto.Set<Funcionario>().Remove(funcionario);
            }
            _contexto.SaveChanges();
        }
    }
}
