using System;

namespace ProjetoIntegradorMVC.Models
{
    public class DiaDaSemana
    {
        public int Id { get; private set; }
        public string Dia { get; private set; }
        private DiaDaSemana() { }
        public DiaDaSemana (string dia)
        {
            Dia = dia;
        }
    }
}