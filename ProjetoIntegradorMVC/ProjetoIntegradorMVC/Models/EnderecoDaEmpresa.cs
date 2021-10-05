using Caelum.Stella.CSharp.Http;
using Caelum.Stella.CSharp.Validation;
using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models
{
    public class EnderecoDaEmpresa
    {
        public int Id { get; set; }
        public string CEP { get; }
        public string Logradouro { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string Localidade { get; }
        public string UF { get; }

        private EnderecoDaEmpresa() { }

        public EnderecoDaEmpresa(string cep)
        {
            var endereco = new ViaCEP().GetEndereco(cep);
            CEP = endereco.CEP;
            Logradouro = endereco.Logradouro;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Localidade = endereco.Localidade;
            UF = endereco.UF;
        }
    }
}