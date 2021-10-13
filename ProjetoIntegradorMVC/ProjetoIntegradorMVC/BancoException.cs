using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC
{
    public class BancoException : ArgumentException
    {
        public BancoException (string message) : base(message) { }
    }
}
