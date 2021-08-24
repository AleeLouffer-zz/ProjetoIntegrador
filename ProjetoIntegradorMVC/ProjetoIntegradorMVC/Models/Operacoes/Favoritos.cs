using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    [Table("Favoritos")]
    public class Favoritos
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<PrestadorDeServico> PrestadorDeServicos { get; set; }
    }
}
