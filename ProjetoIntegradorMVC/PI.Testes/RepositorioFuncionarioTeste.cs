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
        private Empresa _empresa;
        public RepositorioFuncionarioTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();
            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteRepositorioFuncionarios");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _funcionario = new("Cleide", "cleide@cleide.com", "123", "59819300045", _empresa);
            _funcionario.AdicionarExpediente(DayOfWeek.Monday, "08:00", "17:00");
            _funcionario2 = new("Ravona", "ravona@ravona.com", "ravona@ravona.com", "17159590007", _empresa);

            _repositorio = new RepositorioFuncionario(_contexto);
            _repositorio.Adicionar(_funcionario);
            _repositorio.Adicionar(_funcionario2);
            _contexto.SaveChanges();
        }

        [Fact]
        public void Deve_retornar_funcionarios_pelas_ids()
        {
            var ids = new List<int>() { 1, 2 };

            var funcionarios = _repositorio.BuscarFuncionariosPorIds(ids);

            var funcionariosIds = funcionarios.Select(funcionario => funcionario.Id).ToList();
            Assert.Equal(ids, funcionariosIds);
        }

        [Fact]
        public void Deve_adicionar_os_funcionarios()
        {
            var funcionariosASeremAdicionados = new List<Funcionario> { new Funcionario("Cleido","cleido@cleido.com", "123",  "06297337160", _empresa), 
                new Funcionario("Ravon","ravon@ravon.com", "123", "85769390026", _empresa) };
            _repositorio.AdicionarFuncionarios(funcionariosASeremAdicionados);
            var funcionariosRetornados = new List<Funcionario>();

            foreach (var funcionario in funcionariosASeremAdicionados)
            {
                funcionariosRetornados.Add(_repositorio.BuscarFuncionarioPorCpf(funcionario.CPF));
            }

            Assert.Equal(funcionariosASeremAdicionados, funcionariosRetornados);
        }
        
        [Fact]
        public void Deve_retornar_funcionarios_que_trabalham_no_dia()
        {
            var dia = new DateTime(2021, 11, 1);
            var funcionariosQueTrabalhamNoDia = new List<Funcionario>() { _funcionario };
            
            var funcionariosRetornados = _repositorio.BuscarFuncionariosPorDia(dia);
            
            Assert.Equal(funcionariosQueTrabalhamNoDia, funcionariosRetornados);
        }
    }
}
