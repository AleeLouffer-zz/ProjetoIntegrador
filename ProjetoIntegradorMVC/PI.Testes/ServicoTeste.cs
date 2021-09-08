using System;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Operacoes;

namespace PI.Testes
{
    public class ServicoTeste
    {
        private string _descricao;
        private string _preco;
        private decimal _precoDecimal;


        public ServicoTeste()
        {
            _preco = "99";
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

            var servico = new Servico(_descricao, _preco);

            servicoEsperado.ShouldMatch(servico);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_servico_sem_descricao(string descricaoInvalida)
        {
            const string mensagemEsperada = "O serviço deve ter uma descrição";

            void Acao() => new Servico(descricaoInvalida, _preco);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_servico_sem_preco(string precoInvalido)
        {
            const string mensagemEsperada = "O serviço deve ter um preço";

            void Acao() => new Servico(_descricao, precoInvalido);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
