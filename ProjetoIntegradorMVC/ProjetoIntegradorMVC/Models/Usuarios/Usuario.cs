using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; }
        public string Senha { get; }
    }
}
