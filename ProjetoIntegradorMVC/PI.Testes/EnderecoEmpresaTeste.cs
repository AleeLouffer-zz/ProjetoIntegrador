using ProjetoIntegradorMVC.Excecoes;
using ProjetoIntegradorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes
{
    public class EnderecoEmpresaTeste
    {

        public string _cep;
        [Fact]
        public void Deve_criar_endereco_com_cep()
        {
            var cepEsperado = "79002232";

            var endereco = new EnderecoDaEmpresa(cepEsperado);

            Assert.NotNull(endereco);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("00000000000")]
        public void Nao_deve_criar_endereco_com_cep_invalido(string cep)
        {
            const string mensagemEsperada = "CEP inválido";

            void Acao() => new EnderecoDaEmpresa(cep);

            var mensagem = Assert.Throws<CEPInvalidoException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_endereco_com_cep_inexistente()
        {
            var cep = "00000000";
            const string mensagemEsperada = "CEP não existe";

            void Acao() => new EnderecoDaEmpresa(cep);

            var mensagem = Assert.Throws<CEPInvalidoException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_endereco_com_cep_nulo()
        {
            const string mensagemEsperada = "CEP está nulo";

            void Acao() => new EnderecoDaEmpresa(null);

            var mensagem = Assert.Throws<CEPInvalidoException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
