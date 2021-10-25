using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Repositorio;
using Caelum.Stella.CSharp.Validation;
using System;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class Cliente : Usuario
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public List<Agendamento> Agendamentos { get; private set; }

        private Cliente() { }
        public Cliente(string nome, string email, string senha, string cpf)
        {
            ValidarInformacoes(nome, email, senha, cpf);
            Nome = nome;
            Email = email;
            Senha = senha;
            CPF = cpf;
        }

        public void ValidarInformacoes(string nome, string email, string senha, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O campo nome deve ser preenchido");
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("O campo e-mail deve ser preenchido");
            if (string.IsNullOrWhiteSpace(senha)) throw new Exception("É necessário possuir uma senha");
            if (string.IsNullOrWhiteSpace(cpf)) throw new Exception("O campo CPF deve ser preenchido");
            if (!new CPFValidator().IsValid(cpf)) throw new Exception("CPF inválido");
        }
    }
}