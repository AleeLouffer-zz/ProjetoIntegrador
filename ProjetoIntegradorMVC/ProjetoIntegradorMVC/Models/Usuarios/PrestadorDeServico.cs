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
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Localizacao { get; set; }
        public List<Servico> Servicos { get; set; }
        public List<Agendamentos> Agendamentos { get; set; }
    }
}
