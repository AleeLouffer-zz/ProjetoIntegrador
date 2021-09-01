using ProjetoIntegradorMVC.Models.Operacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class PrestadorDeServico : IUsuario
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Localizacao { get; private set; }
        public List<Servico> Servicos { get; private set; }
        public List<Agendamentos> Agendamentos { get; private set; }
        public string NomeEmpresa { get; private set; }
        public string CNPJ { get; private set; }
        public List<Decimal> ContasAReceber { get; private set; }

        public PrestadorDeServico(string email, string senha, string localizacao, string nomeEmpresa, string cnpj)
        {
            Email = email;
            Senha = senha;
            NomeEmpresa = nomeEmpresa;
            CNPJ = cnpj;
            Localizacao = localizacao;
        }
    }
}
