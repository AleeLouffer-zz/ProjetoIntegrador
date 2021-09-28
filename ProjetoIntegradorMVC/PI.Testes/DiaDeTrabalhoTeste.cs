using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using Xunit;

namespace PI.Testes
{
    public class DiaDeTrabalhoTeste
    {
        [Fact]
        public void Deve_criar_um_dia_de_trabalho()
        {
            var diaDeTrabalhoEsperado = "Segunda-Feira";

            var diaDeTrabalho = new DiaDeTrabalho("Segunda-Feira");

            Assert.Equal(diaDeTrabalhoEsperado, diaDeTrabalho.DiaDaSemana);
        }
    }
}