using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class Cliente : Usuario
    {
        public List<string> HistoricoServicos { get; set; }
    }
}
