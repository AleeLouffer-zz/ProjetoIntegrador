using System;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Operacoes;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Repositorio;
using ProjetoIntegradorMVC.Models.ContextoDb;
using Caelum.Stella.CSharp.Vault;

namespace PI.Testes
{
    public class ServicoTeste
    {
        private string _nome;
        private string _descricao;
        private decimal _precoDecimal;
        private Local _local;
        private int _tempoEstimado;

        private BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private RepositorioServico _repositorio;
        private Contexto _contexto;

        public ServicoTeste()
        {
            _nome = "tananan";
            _descricao = "tananan";

            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteServico");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorio = new RepositorioServico(_contexto);
            _precoDecimal = 99m;
            _tempoEstimado = 0;
            _local = Local.ADomicilio;
        }

        [Fact]
        public void Deve_criar_um_servico()
        {
            var servicoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                Preco = _precoDecimal,
                TempoEstimado = _tempoEstimado,
                Local = _local
            }.ToExpectedObject();

            var servico = new Servico(_nome, _descricao, _precoDecimal, _tempoEstimado, Local.ADomicilio);

            servicoEsperado.ShouldMatch(servico);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_servico_sem_nome(string nomeInvalido)
        {
            const string mensagemEsperada = "O serviço deve ter um nome";

            void Acao() => new Servico(nomeInvalido, _descricao, _precoDecimal, _tempoEstimado, _local);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_servico_sem_descricao(string descricaoInvalida)
        {
            const string mensagemEsperada = "O serviço deve ter uma descrição";

            void Acao() => new Servico(_nome, descricaoInvalida, _precoDecimal, _tempoEstimado, _local);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(0)]
        public void Nao_deve_criar_um_servico_sem_preco(decimal precoInvalido)
        {
            const string mensagemEsperada = "O serviço deve ter um preço";

            void Acao() => new Servico(_nome, _descricao, precoInvalido, _tempoEstimado, _local);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_um_servico_sem_tempo_estimado_menor_que_0()
        {
            const string mensagemEsperada = "O tempo estimado é menor que 0 minutos";
            var tempoEstimadoInvalido = -1;

            void Acao() => new Servico(_nome, _descricao, _precoDecimal, tempoEstimadoInvalido, _local);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Deve_verificar_que_servico_existe_no_banco()
        {
            var servico = new Servico(_nome, _descricao, _precoDecimal, _tempoEstimado, _local);
            _repositorio.Adicionar(servico);

            var existeNoBanco = servico.ValidarServicoExistente(_repositorio);

            Assert.True(existeNoBanco);
        }

        [Fact]
        public void Deve_verificar_que_servico_nao_existe_no_banco()
        {
            var servico = new Servico("zapzap2", _descricao, 123m, _tempoEstimado, _local);

            var existeNoBanco = servico.ValidarServicoExistente(_repositorio);

            Assert.False(existeNoBanco);
        }
    }
}
