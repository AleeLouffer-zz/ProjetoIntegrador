using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using Xunit;

namespace PI.Testes
{
    public class DiaDaSemanaTeste
    {
        [Fact]
        public void Deve_criar_um_dia_da_semana()
        {
            var diaDeTrabalhoEsperado = "Segunda-Feira";

            var diaDeTrabalho = new DiaDaSemana("Segunda-Feira");

            Assert.Equal(diaDeTrabalhoEsperado, diaDeTrabalho.Dia);
        }
    }
}