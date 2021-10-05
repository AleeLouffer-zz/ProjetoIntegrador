using ExpectedObjects;
using ProjetoIntegradorMVC.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace PI.Testes
{
    public class JornadaDeTrabalhoTeste
    {
        private readonly List<DiaDeTrabalho>  _diasDeTrabalho;
        private readonly List<HorarioDeTrabalho> _horariosDeTrabalho;
        public JornadaDeTrabalhoTeste()
        {
            _diasDeTrabalho = new List<DiaDeTrabalho> { new DiaDeTrabalho("Segunda"), new DiaDeTrabalho("Terca"), new DiaDeTrabalho("Quarta"), new DiaDeTrabalho("Quinta"), new DiaDeTrabalho("Sexta") };
            _horariosDeTrabalho = new List<HorarioDeTrabalho> { new HorarioDeTrabalho("08:00"), new HorarioDeTrabalho("12:00"), new HorarioDeTrabalho("13:00"), new HorarioDeTrabalho("17:00") };
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
