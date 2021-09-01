using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.LigaçãoModels
{
    public class FuncionariosComServicos
    {
        private FuncionariosComServicos() { }
        public FuncionariosComServicos(List<Funcionario> funcionarios, List<Servico> servicos)
        {
            Funcionarios = funcionarios;
            Servicos = servicos;
        }

        public int Id { get; private set; }
        public int IdServico { get; private set; }
        public int IdFuncionario { get; private set; }
        public List<Funcionario> Funcionarios { get; private set; } = new();
        public List<Servico> Servicos { get; private set; } = new();
    }
}
