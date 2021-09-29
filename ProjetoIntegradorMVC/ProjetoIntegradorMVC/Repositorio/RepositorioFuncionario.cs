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
    public class Repositorio_Funcionario : BaseRepositorio<Funcionario>, IRepositorioFuncionario
    {
        public Repositorio_Funcionario(Contexto contexto) : base(contexto) { }

        public List<Funcionario> BuscarFuncionariosPorIds(List<int> Ids)
        {
            var funcionarios = new List<Funcionario>();

            foreach(var id in Ids)
            {
                var funcionario = GetPorId(id);    
                funcionarios.Add(funcionario);    
            }

            return funcionarios;
        }

        public void Adicionarfuncionarios(List<Funcionario> funcionarios)
        {
            foreach (var funcionario in funcionarios) {
                if (VerificarSeExisteNoBanco(funcionario)) throw new DuplicateNameException("O funcionário já existe");
                Adicionar(funcionario);
            }
            
            _contexto.SaveChanges();
        }

        public override bool ExisteNoBanco(Funcionario funcionario)
        {
            return BuscarFuncionarioPorCpf(funcionario.CPF) != null;
        }

        public Funcionario BuscarFuncionarioPorCpf(string cpf)
        {
            return _contexto.Set<Funcionario>().Where(funcionario => funcionario.CPF == cpf).SingleOrDefault();
        }
    }
}
