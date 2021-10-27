using ProjetoIntegradorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes
{
    public class DataTeste
    {
        [Fact]
        public void Deve_criar_uma_data()
        {
            var dataEsperada = new DateTime(2021, 08, 23);

            var data = new Data("23/08/2021");

            Assert.Equal(dataEsperada, data.Dia);
        }
    }
}
