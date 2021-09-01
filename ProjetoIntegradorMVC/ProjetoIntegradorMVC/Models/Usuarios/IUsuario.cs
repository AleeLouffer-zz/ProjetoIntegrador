using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models
{
    public interface IUsuario
    {
        public int Id { get; }
        public string Email { get; }
        public string Senha { get; }
        public string Localizacao { get; }
    }
}
