using System;
using Xunit;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Operacoes;
using Caelum.Stella.CSharp.Vault;

namespace PI.Testes
{
    public class ServicoTeste
    {
        private string _nome;
        private string _descricao;
        private decimal _preco;

        public ServicoTeste()
        {
            _nome = "tananan";
            _descricao = "tananan";
            _preco = 10m;
        }

        [Fact]
        public void Deve_criar_um_servico()
        {
            var servicoEsperado = new
            {
                Nome = _nome,
                Descricao = _descricao,
                Preco = _preco
            }.ToExpectedObject();

            var servico = new Servico(_nome, _descricao, _preco);

            servicoEsperado.ShouldMatch(servico);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Nao_deve_criar_um_servico_sem_nome(string nomeInvalido)
        {
            const string mensagemEsperada = "O serviço deve ter um nome";

            void Acao() => new Servico(nomeInvalido, _descricao, _preco);

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

            void Acao() => new Servico(_nome, descricaoInvalida, _preco);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Theory]
        [InlineData(0)]
        public void Nao_deve_criar_um_servico_sem_preco(decimal precoInvalido)
        {
            const string mensagemEsperada = "O serviço deve ter um preço";

            void Acao() => new Servico(_nome, _descricao, precoInvalido);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_um_servico_com_tempo_estimado_negativo()
        {
            const string mensagemEsperada = "O tempo estimado é menor que 0 minutos";

            void Acao() => new Servico(_nome, _descricao, _preco, -1);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
