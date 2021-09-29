using System;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Operacoes;

namespace PI.Testes
{
    public class ServicoTeste
    {
        private string _nome;
        private string _descricao;
        private decimal _precoDecimal;

        public ServicoTeste()
        {
            _nome = "tananan";
            _descricao = "tananan";
            _precoDecimal = 99m;
        }

        [Fact]
        public void Deve_criar_um_servico()
        {
            var servicoEsperado = new
            {
                Descricao = _descricao,
                Preco = _precoDecimal
            }.ToExpectedObject();

            var servico = new Servico(_nome, _descricao, _precoDecimal);

            servicoEsperado.ShouldMatch(servico);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_servico_sem_nome(string nomeInvalido)
        {
            const string mensagemEsperada = "O servi�o deve ter um nome";

            void Acao() => new Servico(nomeInvalido, _descricao, _precoDecimal);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_servico_sem_descricao(string descricaoInvalida)
        {
            const string mensagemEsperada = "O servi�o deve ter uma descri��o";

            void Acao() => new Servico(_nome, descricaoInvalida, _precoDecimal);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(0)]
        public void Nao_deve_criar_um_servico_sem_preco(decimal precoInvalido)
        {
            const string mensagemEsperada = "O servi�o deve ter um pre�o";

            void Acao() => new Servico(_nome, _descricao, precoInvalido);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
