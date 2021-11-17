using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes
{
    public class RepositorioAgendamentoTeste
    {
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private readonly Contexto _contexto;
        private readonly RepositorioAgendamento _repositorioAgendamento;
        private readonly RepositorioCliente _repositorioCliente;
        private readonly RepositorioEmpresa _repositorioEmpresa;
        private readonly RepositorioServico _repositorioServico;
        private readonly RepositorioFuncionario _repositorioFuncionario;
        private readonly string _horaEDia;
        private readonly string _horaEDia2;
        private readonly Empresa _empresa;
        private readonly Empresa _empresa2;
        private readonly Servico _servico;
        private readonly Servico _servico2;
        private readonly Funcionario _funcionario;
        private readonly Funcionario _funcionario2;
        private readonly Cliente _cliente;
        private readonly Cliente _cliente2;




        public RepositorioAgendamentoTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteRepositorioAgendamento");

            _repositorioAgendamento = new RepositorioAgendamento(_contexto);
            _repositorioEmpresa = new RepositorioEmpresa(_contexto);
            _repositorioServico = new RepositorioServico(_contexto);
            _repositorioFuncionario = new RepositorioFuncionario(_contexto);
            _repositorioCliente = new RepositorioCliente(_contexto);
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _horaEDia = "12/12/2001 14:00:00";
            _horaEDia2 = "13/12/2001 13:00:00";
            
            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _empresa2 = new Empresa("Inteligencia LTDA", "Inteligencia2", "inteligencia@inteligencia.com.br", "12345", "07593162000120", "79004394");
            _servico = new Servico("Corte", "Corte de Cabelo", 25m, _empresa, Local.NaEmpresa);
            _servico2 = new Servico("CorteGrande", "Corte de Cabelo", 25m, _empresa, Local.NaEmpresa);
            _funcionario = new Funcionario("Cleide", "cleide@cleide.com", "123", "19666360080", _empresa);
            _funcionario2 = new Funcionario("jorje", "jorge@cleide.com", "123", "60118504053", _empresa);
            _cliente = new Cliente("Kaique", "kaique@hotmail.com", "0112", "40082415072");
            _cliente2 = new Cliente("Maria", "maria@gmail.com", "1912", "34870640066");
            
            _repositorioEmpresa.AdicionarEmpresa(_empresa);
            _repositorioEmpresa.AdicionarEmpresa(_empresa2);
            _repositorioServico.AdicionarServicos(new List<Servico>() { _servico, _servico2 });
            _repositorioFuncionario.AdicionarFuncionarios(new List<Funcionario>() {_funcionario, _funcionario2 });
            _repositorioCliente.AdicionarClientes(new List<Cliente>() { _cliente, _cliente2 });
            
            _contexto.SaveChanges();
        }

        [Fact]
        public void Deve_criar_agendamentos_no_banco()
        {
            var agendamento = new Agendamento (_funcionario, _empresa, _servico, _horaEDia, _cliente);
            var agendamento2 = new Agendamento(_funcionario2, _empresa2, _servico2, _horaEDia2, _cliente2);
            var agendamentosASeremRetornados = new List<Agendamento>();
            var agendamentosRetornados = new List<Agendamento>();
            agendamentosASeremRetornados.Add(agendamento);
            agendamentosASeremRetornados.Add(agendamento2);

            _repositorioAgendamento.AdicionarAgendamentos(agendamentosASeremRetornados);

            foreach (var agendamentoRetornado in agendamentosASeremRetornados)
            {
                agendamentosRetornados.Add(_repositorioAgendamento.BuscarAgendamentoPorClienteEServicoEDataEHora(agendamentoRetornado.Cliente, agendamentoRetornado.Servico, agendamentoRetornado.HoraEData));
            }
            Assert.Equal(agendamentosASeremRetornados, agendamentosRetornados);
        }

        [Fact]
        public void Deve_obter_agendamentos_do_dia_do_funcionario()
        {
            var agendamento = new Agendamento(_funcionario, _empresa, _servico, "12/12/2001 15:00:00", _cliente);
            _repositorioAgendamento.Adicionar(agendamento);

            var agentamentosFuncionarios = _repositorioAgendamento.ObterAgendamentoPorDiaDeUmFuncionario(_funcionario, new DateTime(2001, 12, 12));

            Assert.Equal(agendamento, agentamentosFuncionarios[0]);
        }
    }
}

