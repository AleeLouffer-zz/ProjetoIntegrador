using Caelum.Stella.CSharp.Http;
using ExpectedObjects;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PI.Testes
{
    public class EmpresaTeste
    {
        private readonly string _razaoSocial;
        private readonly string _nomeFantasia;
        private readonly string _email;
        private readonly string _senha;
        private readonly string _cnpj;
        private readonly string _cep;

        public EmpresaTeste()
        {
            _razaoSocial = "Inteligencia LTDA";
            _nomeFantasia = "Inteligencia";
            _email = "Fulana@fulana.com.br";
            _senha = "12345";
            _cnpj = "05389493000117";
            _cep = "79004394";
        }

        [Fact]
        public void Deve_criar_uma_empresa()
        {
            var empresaEsperada = new
            {
                RazaoSocial = _razaoSocial,
                NomeFantasia = _nomeFantasia,
                Email = _email,
                Senha = _senha,
                CNPJ = _cnpj,
                Endereco = new ViaCEP().GetEndereco(_cep),
            }.ToExpectedObject();

            var empresa = new Empresa(_razaoSocial, _nomeFantasia, _email, _senha, _cnpj, _cep);

            empresaEsperada.ShouldMatch(empresa);
        }
    }
}
