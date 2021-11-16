using ProjetoIntegradorMVC.Models.Operacoes;
using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    [Index(nameof(CPF), IsUnique = true)]
    public class Funcionario : Usuario
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public Empresa Empresa { get; private set; }
        public int EmpresaId { get; private set; }
        public List<Agendamento> Agendamentos { get; private set; } = new();
        public List<ExpedienteDeTrabalho> ExpedientesDeTrabalho { get; private set; } = new();

        private Funcionario() { }

        public Funcionario (string nome, string email, string senha, string cpf, Empresa empresa)
        {
            ValidarInformacoes(nome, email, senha, cpf);
            Nome = nome;
            Email = email;
            Senha = senha;
            CPF = cpf;
            Empresa = empresa;
            EmpresaId = empresa.Id;
        }

        public void AdicionarExpediente(DayOfWeek diaDaSemana, string horaInicial, string horaFinal)
        {
            ExpedientesDeTrabalho.Add(new ExpedienteDeTrabalho(this, diaDaSemana, horaInicial, horaFinal));
        }

        public void AdicionarExpedienteComIntervalo(DayOfWeek diaDaSemana, string horaInicial, string horaFinal, string inicioIntervalo, string finalIntervalo)
        {
            ExpedientesDeTrabalho.Add(new ExpedienteDeTrabalho(this, diaDaSemana, horaInicial, horaFinal, inicioIntervalo, finalIntervalo));
        }

        public void ValidarInformacoes(string nome, string email, string senha, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O funcionário deve ter um nome");
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("O funcionário deve ter um email");
            if (string.IsNullOrWhiteSpace(senha)) throw new Exception("O funcionário deve ter uma senha");
            if (string.IsNullOrWhiteSpace(cpf)) throw new Exception("O funcionário deve ter um cpf");
            if (!new CPFValidator().IsValid(cpf)) throw new Exception("O funcionario deve ter um CPF valido");
        }
    }
} 