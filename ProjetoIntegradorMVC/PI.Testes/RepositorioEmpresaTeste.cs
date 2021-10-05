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

namespace PI.Testes
{
    public class RepositorioEmpresaTeste
    {
        private readonly RepositorioEmpresa _repositorio;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private readonly Contexto _contexto;
        private Empresa _empresa;
        private readonly Funcionario _funcionario;
        private readonly Servico _servico;

        public RepositorioEmpresaTeste()
        {
             _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteEmpresa");

            _repositorio = new RepositorioEmpresa(_contexto);

            _funcionario = new Funcionario("Cleide", "cleide@hotmail.com", "123", "2412321311");
            _servico = new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m);
            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");

            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);
            _contexto.Empresas.Add(_empresa);
            _contexto.SaveChanges();
        }   

        
        [Fact]
        public void Deve_vincular_um_funcionario_a_uma_empresa()
        {
            var funcionarioEsperado = new Funcionario("Cleide", "cleide@hotmail.com", "123", "2412321311");

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
            var servicoEsperado = new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m);

            _repositorio.VincularServico(_empresa.CNPJ, servicoEsperado);

            Assert.Equal(servicoEsperado.EmpresaId, _empresa.Id);
        }

        [Fact]
        public void Nao_deve_vincular_servico_de_uma_empresa_que_nao_existe()
        {
            const string mensagemEsperada = "Empresa não encontrada";

            void Acao() => _repositorio.VincularServico("28868694000100", _servico);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_verificar_a_empresa_existente()
        {
            var empresaExistente = new Empresa("Fulana de Tal LTDA", "Fulana de Tal", "fulana@fulana.com.br", "123", "05042060000190", "79004394");
            _contexto.Empresas.Add(empresaExistente);
            _contexto.SaveChanges();

            var empresaExiste = _repositorio.VerificarSeEmpresaExiste(empresaExistente.CNPJ);

            Assert.True(empresaExiste);
        }

        [Fact]
        public void Nao_deve_adicionar_empresa_existente()
        {
            const string mensagemEsperada = "A Empresa já existe";

            void Acao() => _repositorio.AdicionarEmpresa(_empresa);

            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}