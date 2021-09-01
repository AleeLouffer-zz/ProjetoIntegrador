using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class Cliente : IUsuario
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Localizacao { get; private set; }

        public Cliente(string email, string senha, string localizacao)
        {
            Email = email;
            Senha = senha;
            Localizacao = localizacao;
        }

    }
}
