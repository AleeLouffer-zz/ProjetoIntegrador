using ProjetoIntegradorMVC.Models.Operacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class Funcionario 
    {
        public int Id { get; set; }
        public string Nome { get; private set;  }
        private Funcionario() { }
        public Funcionario (string nome)
        {
            Nome = nome;
        }
    }
} 