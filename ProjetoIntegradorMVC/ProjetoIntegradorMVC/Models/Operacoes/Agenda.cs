using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    [Table("Agenda")]
    public class Agenda
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "InformacoesServicoId")]
        [Column("InformacoesServicoId")]
        public int InformacoesServicoId { get; set; }

        [Display(Name = "ClienteId")]
        [Column("ClienteId")]
        public int ClienteId { get; set; }

        [Display(Name = "PrestadorId")]
        [Column("PrestadorId")]
        public int PrestadorId { get; set; }

        [Display(Name = "ServicoId")]
        [Column("ServicoId")]

        public int ServicoId { get; set; }
        public DateTime InformacoesServico { get; set; }
        public Cliente Cliente { get; set; }
        public PrestadorDeServico Prestador { get; set; }
        public Servico Servico { get; set; }
    }
}
