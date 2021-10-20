using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Repositorio;
using Caelum.Stella.CSharp.Validation;
using System;
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
        public JornadaDeTrabalho JornadaDeTrabalho { get; private set; }
        private Funcionario() { }
        public Funcionario (string nome, string email, string senha, string cpf, JornadaDeTrabalho jornada, Empresa empresa)
        {
            ValidarInformacoes(nome, email, senha, cpf);
            Nome = nome;
            Email = email;
            Senha = senha;
            CPF = cpf;
            JornadaDeTrabalho = jornada;
            Empresa = empresa;
            EmpresaId = empresa.Id;
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