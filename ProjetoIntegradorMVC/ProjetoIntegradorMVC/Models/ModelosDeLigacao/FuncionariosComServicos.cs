using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.LigaçãoModels
{
    public class FuncionariosComServicos : ClasseBase
    {
        public Funcionario Funcionario { get; private set; }
        public int FuncionarioId { get; private set; }
        public Servico Servico { get; private set; }
        public int ServicoId { get; private set; }
        public Empresa Empresa { get; private set; }

        private FuncionariosComServicos() { }

        public FuncionariosComServicos(Funcionario funcionario, Servico servico, Empresa empresa)
        {
            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;
            Servico = servico;
            ServicoId = servico.Id;
            Empresa = empresa;
        }
    }
}
