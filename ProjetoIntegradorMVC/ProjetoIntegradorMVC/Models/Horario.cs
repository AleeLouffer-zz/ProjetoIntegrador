using System;

namespace ProjetoIntegradorMVC.Models
{
    public class Horario : ClasseBase
    {
        public DateTime Hora { get; protected set; }
        
        public Horario(DateTime hora)
        {
            Hora = hora;
        }

    }
}
