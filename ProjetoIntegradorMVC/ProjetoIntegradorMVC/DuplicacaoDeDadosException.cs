using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC
{
    public class DuplicacaoDeDadosException : DbUpdateException
    {
        public DuplicacaoDeDadosException (string message) : base(message) { }
    }
}
