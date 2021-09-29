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
        }

        [Fact]
        public void Deve_criar_um_servico()
        {
            var servicoEsperado = new
            {
                Descricao = _descricao,
                Preco = _preco
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
            const string mensagemEsperada = "O serviço deve ter um nome";

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
            const string mensagemEsperada = "O serviço deve ter uma descrição";

            void Acao() => new Servico(_nome, descricaoInvalida, _precoDecimal);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(0)]
        public void Nao_deve_criar_um_servico_sem_preco(decimal precoInvalido)
        {
            const string mensagemEsperada = "O tempo estimado é menor que 0 minutos";

            void Acao() => new Servico(_nome, _descricao, _preco, -1);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
