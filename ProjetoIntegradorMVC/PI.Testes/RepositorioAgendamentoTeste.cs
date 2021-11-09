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
        private readonly Contexto _contexto;
        private readonly RepositorioAgendamento _repositorioAgendamento;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private readonly string _horaEDia;
        private readonly string _horaEDia2;

        public RepositorioAgendamentoTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteRepositorioAgendamento");

            _repositorioAgendamento = new RepositorioAgendamento(_contexto);
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _horaEDia = "12/12/2001 14:00:00";
            _horaEDia2 = "13/12/2001 13:00:00";
        }
        [Fact]
        public void Deve_criar_agendamentos_no_banco()
        {
            var empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            var empresa2 = new Empresa("Inteligencia LTDA", "Inteligencia2", "inteligencia@inteligencia.com.br", "12345", "07593162000120", "79004394");
            var servico = new Servico("Corte", "Corte de Cabelo", 25m, empresa, Local.NaEmpresa);
            var servico2 = new Servico("CorteGrande", "Corte de Cabelo", 25m, empresa, Local.NaEmpresa);
            var funcionario = new Funcionario("Cleide", "cleide@cleide.com", "123", "19666360080", empresa);
            var funcionario2 = new Funcionario("jorje", "jorge@cleide.com", "123", "60118504053", empresa);
            var cliente = new Cliente("Kaique", "kaique@hotmail.com", "0112", "40082415072");
            var cliente2 = new Cliente("Maria", "maria@gmail.com", "1912", "34870640066");
            var agendamento = new Agendamento (funcionario, empresa, servico, _horaEDia, cliente);
            var agendamento2 = new Agendamento(funcionario2, empresa2, servico2, _horaEDia2, cliente2);
            var agendamentosASeremRetornados = new List<Agendamento>();
            var agendamentosRetornados = new List<Agendamento>();
            agendamentosASeremRetornados.Add(agendamento);
            agendamentosASeremRetornados.Add(agendamento2);

            _repositorioAgendamento.AdicionarAgendamento(agendamentosASeremRetornados);

            foreach (var agendamentoRetornado in agendamentosASeremRetornados)
            {
                agendamentosRetornados.Add(_repositorioAgendamento.BuscarAgendamentoPorClienteEServicoEDataEHora(agendamentoRetornado.Cliente, agendamentoRetornado.Servico, agendamentoRetornado.HoraEData));
            }
            Assert.Equal(agendamentosASeremRetornados, agendamentosRetornados);
        }
    }
}

