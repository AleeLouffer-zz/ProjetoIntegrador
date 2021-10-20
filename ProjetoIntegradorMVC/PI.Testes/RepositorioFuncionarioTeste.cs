using Microsoft.EntityFrameworkCore;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

namespace PI.Testes
{
    public class RepositorioFuncionarioTeste
    {
        private readonly Contexto _contexto;
        private readonly RepositorioFuncionario _repositorio;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private Funcionario _funcionario;
        private Funcionario _funcionario2;
        private JornadaDeTrabalho _jornada;
        private Empresa _empresa;
        public RepositorioFuncionarioTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteFuncionarios");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);


            var diasDeTrabalho = new List<DiaDeTrabalho> { new DiaDeTrabalho("Segunda"), new DiaDeTrabalho("Terca"), new DiaDeTrabalho("Quarta"), new DiaDeTrabalho("Quinta"), new DiaDeTrabalho("Sexta") };
            var horariosDeTrabalho = new List<HorarioDeTrabalho> { new HorarioDeTrabalho("08:00"), new HorarioDeTrabalho("12:00"), new HorarioDeTrabalho("13:00"), new HorarioDeTrabalho("17:00") };
            _jornada = new(diasDeTrabalho, horariosDeTrabalho);
            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _funcionario = new("Cleide", "cleide@cleide.com", "123", "59819300045", _jornada, _empresa);
            _funcionario2 = new("Ravona", "ravona@ravona.com", "ravona@ravona.com", "17159590007", _jornada, _empresa);
            _repositorio = new RepositorioFuncionario(_contexto);
        }

        [Fact]
        public void Deve_retornar_funcionarios_pelas_ids()
        {
            _contexto.Funcionarios.Add(_funcionario);
            _contexto.Funcionarios.Add(_funcionario2);
            _contexto.SaveChanges();
            var ids = new List<int>() { 1, 2 };

            var funcionarios = _repositorio.BuscarFuncionariosPorIds(ids);

            var funcionariosIds = funcionarios.Select(funcionario => funcionario.Id).ToList();
            Assert.Equal(ids, funcionariosIds);
        }

        [Fact]
        public void Deve_adicionar_os_funcionarios()
        {
            var funcionariosASeremAdicionados = new List<Funcionario> { new Funcionario("Cleido","cleido@cleido.com", "123",  "06297337160", _jornada, _empresa), 
                new Funcionario("Ravon","ravon@ravon.com", "123", "85769390026", _jornada, _empresa) };
            _repositorio.AdicionarFuncionarios(funcionariosASeremAdicionados);
            var funcionariosRetornados = new List<Funcionario>();

            foreach (var funcionario in funcionariosASeremAdicionados)
            {
                funcionariosRetornados.Add(_repositorio.BuscarFuncionarioPorCpf(funcionario.CPF));
            }

            Assert.Equal(funcionariosASeremAdicionados, funcionariosRetornados);
        }
    }
}
