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
    public class Repositorio_Funcionario : BaseRepositorio<Funcionario>, IRepositorio_Funcionario
    {
        public Repositorio_Funcionario(Contexto contexto) : base(contexto) { }

        public List<Funcionario> GetFuncionarios(List<int> Ids)
        {
            var funcionarios = new List<Funcionario>();

            foreach(var id in Ids)
            {
                GetPorId(id);    
            }

            return funcionarios;
        }

        public void AddFuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) {
                if (VerificarSeExisteNoBanco(funcionario)) throw new DuplicateNameException("O funcionário já existe");
                Adicionar(funcionario);
            }
            
            _contexto.SaveChanges();
        }

        public override bool ExisteNoBanco(Funcionario objetoNoBanco)
        {
            if(objetoNoBanco.CPF == objetoNoBanco.CPF) return true;
            return false;
        }
    }
}
