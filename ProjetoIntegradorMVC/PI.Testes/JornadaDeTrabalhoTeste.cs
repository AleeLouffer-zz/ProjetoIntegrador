using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace PI.Testes
{
    public class JornadaDeTrabalhoTeste
    {
        private readonly List<DiaDaSemana>  _diasDeTrabalho;
        private readonly List<Horario> _horariosDeTrabalho;
        public JornadaDeTrabalhoTeste()
        {
            _diasDeTrabalho = new List<DiaDaSemana> { new DiaDaSemana("Segunda"), new DiaDaSemana("Terca"), new DiaDaSemana("Quarta"), new DiaDaSemana("Quinta"), new DiaDaSemana("Sexta") };
            _horariosDeTrabalho = new List<Horario> { new Horario("08:00"), new Horario("12:00"), new Horario("13:00"), new Horario("17:00") };
        }

        [Fact]
        public void Deve_criar_uma_jornada_de_trabalho()
        {
            var jornadaDeTrabalhoEsperada = new
            {
                DiasDeTrabalho = _diasDeTrabalho,
                HorariosDeTrabalho = _horariosDeTrabalho
            }.ToExpectedObject();

            var jornadaDeTrabalho = new JornadaDeTrabalho(_diasDeTrabalho, _horariosDeTrabalho);

            jornadaDeTrabalhoEsperada.ShouldMatch(jornadaDeTrabalho);
        }

        [Fact]
        public void Nao_deve_criar_uma_jornada_de_trabalho_sem_dias_de_trabalho()
        {
            const string mensagemEsperada = "A jornada deve ter dias de trabalho";

            void Acao() => new JornadaDeTrabalho(null, _horariosDeTrabalho);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }

        [Fact]
        public void Nao_deve_criar_uma_jornada_de_trabalho_sem_horarios_de_trabalho()
        {
            const string mensagemEsperada = "A jornada deve ter horários de trabalho";

            void Acao() => new JornadaDeTrabalho(_diasDeTrabalho, null);

            var mensagem = Assert.Throws<Exception>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}
