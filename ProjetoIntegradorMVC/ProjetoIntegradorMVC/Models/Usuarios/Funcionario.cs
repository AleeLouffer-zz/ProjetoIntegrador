using System;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class Funcionario : Usuario
    {
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public JornadaDeTrabalho JornadaDeTrabalho { get; private set; }
        private Funcionario() { }
        public Funcionario (string nome, string email, string senha, string cpf, JornadaDeTrabalho jornada)
        {
            ValidarInformacoes(nome, email, senha, cpf);
            Nome = nome;
            Email = email;
            Senha = senha;
            CPF = cpf;
            JornadaDeTrabalho = jornada;
        }
        public void ValidarInformacoes(string nome, string email, string senha, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O funcionário deve ter um nome");
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("O funcionário deve ter um email");
            if (string.IsNullOrWhiteSpace(senha)) throw new Exception("O funcionário deve ter uma senha");
            if (string.IsNullOrWhiteSpace(cpf)) throw new Exception("O funcionário deve ter um cpf");
        }
    }
} 