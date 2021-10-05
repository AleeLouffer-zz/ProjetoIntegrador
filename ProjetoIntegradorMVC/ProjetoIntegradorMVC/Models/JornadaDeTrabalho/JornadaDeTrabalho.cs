using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using ProjetoIntegradorMVC.Models;

namespace ProjetoIntegradorMVC.Models
{
    public class JornadaDeTrabalho
    {
        public int Id { get; private set;  }
        public List<DiaDaSemana> DiasDeTrabalho { get; private set; } = new();
        public List<Horario> HorariosDeTrabalho { get; private set; } = new();
        private JornadaDeTrabalho() { }
        public JornadaDeTrabalho(List<DiaDaSemana> diasDeTrabalho, List<Horario> horariosDeTrabalho)
        {
            ValidarInformacoes(diasDeTrabalho, horariosDeTrabalho);
            DiasDeTrabalho = diasDeTrabalho;
            HorariosDeTrabalho = horariosDeTrabalho;
        }
        public void ValidarInformacoes(List<DiaDaSemana> diasDeTrabalho, List<Horario> horarioDeTrabalho)
        {
            if (diasDeTrabalho == null || !diasDeTrabalho.Any()) throw new Exception("A jornada deve ter dias de trabalho");
            if (horarioDeTrabalho == null || !horarioDeTrabalho.Any()) throw new Exception("A jornada deve ter horários de trabalho");
        }
    }
}