using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    [Table("PrestadorDeServico")]
    public class PrestadorDeServico : IUsuario
    {
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Column("Senha")]
        public string Senha { get; set; }

        [Display(Name = "Localizacao")]
        [Column("Localizacao")]
        public string Localizacao { get; set; }

        [Display(Name = "ServicosId")]
        [Column("ServicosId")]
        public List<int> ServicosId { get; set; }

        [Display(Name = "ContasAReceberId")]
        [Column("ContasAReceberId")]
        public List<int> ContasAReceberId { get; set; }

        [Display(Name = "HistoricoClientesId")]
        [Column("HistoricoClientesId")]
        public List<int> HistoricoClientesId { get; set; }

        public List<Servico> Servicos { get; set; }
        public List<Decimal> ContasAReceber { get; set; }
        public List<Cliente> HistoricoClientes { get; set; }
    }
}
