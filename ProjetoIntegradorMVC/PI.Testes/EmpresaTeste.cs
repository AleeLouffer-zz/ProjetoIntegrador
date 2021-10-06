using Caelum.Stella.CSharp.Http;
using ExpectedObjects;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
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
    public class EmpresaTeste
    {
        private readonly string _razaoSocial;
        private readonly string _nomeFantasia;
        private readonly string _email;
        private readonly string _senha;
        private readonly string _cnpj;
        private readonly string _cep;

        private BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private RepositorioEmpresa _repositorio;
        private Contexto _contexto;

        public EmpresaTeste()
        {
            _razaoSocial = "Inteligencia LTDA";
            _nomeFantasia = "Inteligencia";
            _email = "Fulana@fulana.com.br";
            _senha = "12345";
            _cnpj = "05389493000117";
            _cep = "79004394";

            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteEmpresa");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorio = new RepositorioEmpresa(_contexto);
        }

        [Fact]
        public void Deve_criar_uma_empresa()
        {
            var empresaEsperada = new
            {
                RazaoSocial = _razaoSocial,
                NomeFantasia = _nomeFantasia,
                Email = _email,
                Senha = _senha,
                CNPJ = _cnpj,
                Endereco = new EnderecoDaEmpresa(_cep),
            }.ToExpectedObject();

            var empresa = new Empresa(_razaoSocial, _nomeFantasia, _email, _senha, _cnpj, _cep);

            empresaEsperada.ShouldMatch(empresa);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_uma_empresa_sem_razao_social(string razaoSocialInvalida)
        {
            const string mensagemEsperada = "A empresa deve ter uma Razao Social";

            void Acao() => new Empresa(razaoSocialInvalida, _nomeFantasia, _email, _senha, _cnpj, _cep);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_uma_empresa_sem_nome_fantasia(string nomeFantasiaInvalido)
        {
            const string mensagemEsperada = "A empresa deve ter um Nome Fantasia";

            void Acao() => new Empresa(_razaoSocial, nomeFantasiaInvalido, _email, _senha, _cnpj, _cep);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_uma_empresa_sem_email(string emailInvalido)
        {
            const string mensagemEsperada = "A empresa deve ter um email";

            void Acao() => new Empresa(_razaoSocial, _nomeFantasia, emailInvalido, _senha, _cnpj, _cep);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_uma_empresa_sem_senha(string senhaInvalida)
        {
            const string mensagemEsperada = "A empresa deve ter uma senha";

            void Acao() => new Empresa(_razaoSocial, _nomeFantasia, _email, senhaInvalida, _cnpj, _cep);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("111111111111111")]
        public void Nao_deve_criar_uma_empresa_com_cnpj_invalido(string cnpj)
        {
            const string mensagemEsperada = "A empresa deve ter um CNPJ valido";

            void Acao() => new Empresa(_razaoSocial, _nomeFantasia, _email, _senha, cnpj, _cep);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_verificar_se_empresa_existe_no_banco()
        {
            var empresa = new Empresa(_razaoSocial, _nomeFantasia, _email, _senha, _cnpj, _cep);
            _repositorio.Adicionar(empresa);

            var existeNoBanco = empresa.ValidarEmpresaExistente(_repositorio);

            Assert.True(existeNoBanco);
        }

        [Fact]
        public void Deve_verificar_se_empresa_nao_existe_no_banco()
        {
            var empresa = new Empresa(_razaoSocial, _nomeFantasia, _email, _senha, "28868694000100", _cep);

            var existeNoBanco = empresa.ValidarEmpresaExistente(_repositorio);

            Assert.False(existeNoBanco);
        }
    }
}
