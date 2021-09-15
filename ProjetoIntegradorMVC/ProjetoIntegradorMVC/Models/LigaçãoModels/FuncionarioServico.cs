using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;


namespace ProjetoIntegradorMVC.Models.LigaçãoModels
{
    public class FuncionarioServico
    {
        public Funcionario Funcionario { get; private set; }
        public int FuncionarioId { get; private set; }
        public Servico Servico { get; private set; }
        public int ServicoId { get; private set; }
        public int Id { get; private set; }

        private FuncionarioServico() { }

        public FuncionarioServico(Funcionario funcionario, Servico servico)
        {
            this.Funcionario = funcionario;
            this.Servico = servico;
        }
    }
}
