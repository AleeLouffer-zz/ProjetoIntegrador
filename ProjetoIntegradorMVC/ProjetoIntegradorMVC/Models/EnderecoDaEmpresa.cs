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
            Endereco endereco = ObterEnderecoCompleto(cep);
            CEP = endereco.CEP;
            Logradouro = endereco.Logradouro;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Localidade = endereco.Localidade;
            UF = endereco.UF;
        }

        private static Endereco ObterEnderecoCompleto(string cep)
        {
            try
            {
                return new ViaCEP().GetEndereco(cep);
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