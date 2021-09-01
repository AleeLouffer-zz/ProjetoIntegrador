using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    [Table("Servico")]
    public class Servico
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }

        private Servico()
        {

        }
        public Servico(string descricao, decimal preco)
        {
            Descricao = descricao;
            Preco = preco;
        }
    }
}