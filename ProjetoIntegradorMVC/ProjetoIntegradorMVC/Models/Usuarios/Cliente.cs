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
    [Table("Cliente")]
    public class Cliente : ModeloBase, IUsuario
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

        [Display(Name = "HistoricoServicosId")]
        [Column("HistoricoServicosId")]
        public int HistoricoServicosId { get; set; }

        [Display(Name = "FavoritosId")]
        [Column("FavoritosId")]
        public int FavoritosId { get; set; }

        public List<Servico> HistoricoServicos { get; set; }
        public List<PrestadorDeServico> Favoritos { get; set; }

        
    }
}
