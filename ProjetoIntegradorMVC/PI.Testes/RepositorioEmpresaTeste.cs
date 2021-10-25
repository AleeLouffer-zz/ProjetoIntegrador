﻿using Microsoft.EntityFrameworkCore;
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
    public class RepositorioEmpresaTeste
    {
        private readonly RepositorioEmpresa _repositorio;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private readonly Contexto _contexto;
        private readonly Empresa _empresa;
        private readonly Funcionario _funcionario;
        private readonly Servico _servico;
        private readonly JornadaDeTrabalho _jornada;

        public RepositorioEmpresaTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteRepositorioEmpresa");

            _repositorio = new RepositorioEmpresa(_contexto);

            var diasDeTrabalho = new List<DiaDaSemana> { new DiaDaSemana("Segunda"), new DiaDaSemana("Terca"), new DiaDaSemana("Quarta"), new DiaDaSemana("Quinta"), new DiaDaSemana("Sexta") };
            var horariosDeTrabalho = new List<Horario> { new Horario("08:00"), new Horario("12:00"), new Horario("13:00"), new Horario("17:00") };
            _jornada = new JornadaDeTrabalho(diasDeTrabalho, horariosDeTrabalho);

            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _funcionario = new Funcionario("Cleide", "cleide@hotmail.com", "123", "06297337160", _jornada, _empresa);
            _servico = new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m, _empresa, Local.ADomicilio);

            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);
            _contexto.Empresas.Add(_empresa);
            _contexto.SaveChanges();
        }   

        
        [Fact]
        public void Deve_vincular_um_funcionario_a_uma_empresa()
        {
            var funcionarioEsperado = new Funcionario("Cleide", "cleide@hotmail.com", "123", "06297337160", _jornada, _empresa);

            _repositorio.VincularFuncionario(_empresa.CNPJ, funcionarioEsperado);

            Assert.Equal(funcionarioEsperado.EmpresaId, _empresa.Id);
        }

        [Fact]
        public void Nao_deve_vincular_funcionario_de_uma_empresa_que_nao_existe()
        {
            const string mensagemEsperada = "Empresa não encontrada";

            void Acao() => _repositorio.VincularFuncionario("28868694000100", _funcionario);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_vincular_um_servico_a_uma_empresa()
        {
            var servicoEsperado = new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m, _empresa, Local.ADomicilio);

            _repositorio.VincularServico(_empresa.CNPJ, servicoEsperado);

            Assert.Equal(servicoEsperado.Empresa.Id, _empresa.Id);
        }

        [Fact]
        public void Nao_deve_vincular_servico_de_uma_empresa_que_nao_existe()
        {
            const string mensagemEsperada = "Empresa não encontrada";

            void Acao() => _repositorio.VincularServico("28868694000100", _servico);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}