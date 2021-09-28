using System;

namespace ProjetoIntegradorMVC.Models
{
    public class DiaDeTrabalho
    {
        public int Id { get; private set; }
        public string DiaDaSemana { get; private set; }
        private DiaDeTrabalho() { }
        public DiaDeTrabalho (string diaDaSemana)
        {
            DiaDaSemana = diaDaSemana;
        }
    }
}