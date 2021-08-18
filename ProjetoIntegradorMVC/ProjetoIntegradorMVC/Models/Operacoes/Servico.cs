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
    public class Servico : ModeloBase
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Descricao")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Preco")]
        [Column("Preco")]
        public Decimal Preco { get; set; }

        [Display(Name = "PrestadorId")]
        [Column("PrestadorId")]
        public int PrestadorId { get; set; }

        [Display(Name = "ClienteId")]
        [Column("ClienteId")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }
        public PrestadorDeServico Prestador { get; set; }
    }
}
