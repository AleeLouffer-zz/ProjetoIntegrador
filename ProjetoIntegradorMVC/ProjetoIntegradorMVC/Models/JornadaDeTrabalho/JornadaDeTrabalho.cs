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
        public List<DiaDeTrabalho> DiasDeTrabalho { get; private set; } = new();
        public List<HorarioDeTrabalho> HorariosDeTrabalho { get; private set; } = new();
        private JornadaDeTrabalho() { }
        public JornadaDeTrabalho(List<DiaDeTrabalho> diasDeTrabalho, List<HorarioDeTrabalho> horariosDeTrabalho)
        {
            ValidarInformacoes(diasDeTrabalho, horariosDeTrabalho);
            DiasDeTrabalho = diasDeTrabalho;
            HorariosDeTrabalho = horariosDeTrabalho;
        }
        public void ValidarInformacoes(List<DiaDeTrabalho> diasDeTrabalho, List<HorarioDeTrabalho> horarioDeTrabalho)
        {
            if (diasDeTrabalho == null || !diasDeTrabalho.Any()) throw new Exception("A jornada deve ter dias de trabalho");
            if (horarioDeTrabalho == null || !horarioDeTrabalho.Any()) throw new Exception("A jornada deve ter horários de trabalho");
        }
    }
}