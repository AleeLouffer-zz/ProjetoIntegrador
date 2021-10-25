using ProjetoIntegradorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes
{
    public class DataEHoraTeste
    {
        [Fact]
        public void Deve_criar_uma_data_e_hora()
        {
            var dataEsperada = new DateTime(2008, 5, 1, 8, 30, 52);

            var dataEHora = new DataEHora("01/05/2008 08:30:52");

            Assert.Equal(dataEsperada, dataEHora.HoraEData);
        }
    }
}
