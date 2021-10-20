using Caelum.Stella.CSharp.Http;
using Caelum.Stella.CSharp.Http.Exceptions;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Excecoes;

namespace ProjetoIntegradorMVC.Models
{
    [Owned]
    public class EnderecoDaEmpresa
    {
        public string CEP { get; }
        public string Logradouro { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string Localidade { get; }
        public string UF { get; }

        protected EnderecoDaEmpresa() { }

        public EnderecoDaEmpresa(string cep)
        {
            try
            {
                var endereco = new ViaCEP().GetEndereco(cep);
                CEP = endereco.CEP;
                Logradouro = endereco.Logradouro;
                Complemento = endereco.Complemento;
                Bairro = endereco.Bairro;
                Localidade = endereco.Localidade;
                UF = endereco.UF;
            }
            catch (InvalidZipCodeFormat)
            {
                throw new CEPInvalidoException("CEP inválido");
            }
            catch (ZipCodeDoesNotExist)
            {
                throw new CEPInvalidoException("CEP não existe");
            }
            catch (HttpRequestFailException)
            {
                throw new CEPInvalidoException("CEP está nulo");
            }
        }
    }
}