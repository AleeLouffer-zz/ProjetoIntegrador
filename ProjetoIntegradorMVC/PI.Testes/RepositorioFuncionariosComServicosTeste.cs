using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ProjetoIntegradorMVC.Models.LigaçãoModels;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Models;

namespace PI.Testes
{
    public class RepositorioFuncionariosComServicosTeste
    {
        private readonly Funcionario _funcionario;
        private readonly Servico _servico;
        private readonly Funcionario _funcionario2;
        private readonly Servico _servico2;
        private readonly Contexto _contexto;
        private readonly RepositorioFuncionariosComServicos _repositorio;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private readonly JornadaDeTrabalho _jornada;
        public RepositorioFuncionariosComServicosTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteFuncionariosComServicos");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorio = new RepositorioFuncionariosComServicos(_contexto);

            var diasDeTrabalho = new List<DiaDeTrabalho> { new DiaDeTrabalho("Segunda"), new DiaDeTrabalho("Terca"), new DiaDeTrabalho("Quarta"), new DiaDeTrabalho("Quinta"), new DiaDeTrabalho("Sexta") };
            var horariosDeTrabalho = new List<HorarioDeTrabalho> { new HorarioDeTrabalho("08:00"), new HorarioDeTrabalho("12:00"), new HorarioDeTrabalho("13:00"), new HorarioDeTrabalho("17:00") };
            _jornada = new(diasDeTrabalho, horariosDeTrabalho);

            _funcionario = new Funcionario("Cleide", "cleide@cleide.com.br", "123", "85769390026", _jornada);
            _funcionario2 = new Funcionario("Cleide", "cleide@cleide.com.br", "123", "25807814045", _jornada);
            _servico = new Servico("Corte", "Corte de Cabelo", 50m);
            _servico2 = new Servico("Manicure", "Manicure", 30m);
        }

        [Fact]
        public void Deve_adicionar_um_funcionario_com_servico()
        {
            var funcComServico = new FuncionariosComServicos(_funcionario, _servico);

            _repositorio.AdicionarFuncionariosComServicos(funcComServico);

            Assert.Equal(1, _contexto.FuncionariosComServicos.Count());
        }

        [Fact]
        public void Deve_adicionar_varios_funcionarios_com_servicos()
        { 
            var funcionariosComServicos = new List<FuncionariosComServicos> { new FuncionariosComServicos(_funcionario, _servico), new FuncionariosComServicos(_funcionario2, _servico2) };

            _repositorio.AdicionarFuncionariosComServicos(funcionariosComServicos);

            Assert.Equal(2, _contexto.FuncionariosComServicos.Count());
        }

        [Fact]
        public void Deve_listar_ids_dos_funcionario_pela_id_de_servico()
        {
            var idEsperado = _contexto.Servicos.Where(a => a.Nome == "Corte").Select(a => a.Id).SingleOrDefault();
            var idsFuncionariosEsperados = _contexto.FuncionariosComServicos.Select(a => a.FuncionarioId).ToList();

            var idFuncionario = _repositorio.BuscarIdsDosFuncionariosPeloIdDoServico(idEsperado);

            Assert.Equal(idsFuncionariosEsperados, idFuncionario);
        }

        [Fact]
        public void Deve_vincular_funcionario_com_servicos()
        {
            var funcionarios = new List<Funcionario> { _funcionario, _funcionario2 };
            var servicos = new List<Servico> { _servico, _servico2 };

            var funcionariosComServicos = _repositorio.VincularFuncionariosComServicos(funcionarios, servicos);
            
            Assert.Equal(4, funcionariosComServicos.Count());
        }
    }
}
