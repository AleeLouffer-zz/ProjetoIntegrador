using Caelum.Stella.CSharp.Http;
using Caelum.Stella.CSharp.Validation;
using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Usuarios
{
    public class Empresa : Usuario
    {
        private RepositorioEmpresa _repositorioEmpresa;
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public string CNPJ { get; private set; }
        public EnderecoDaEmpresa Endereco { get; private set; }
        public List<Funcionario> Funcionarios { get; private set; }
        public List<Servico> Servicos { get; private set; }
        public List<FuncionariosComServicos> FuncionariosComServicos { get; private set; }

        private Empresa() { }

        public Empresa(string razaoSocial, string nomeFantasia, string email, string senha, string cnpj, string cep)
        {
            Funcionarios = new List<Funcionario>();
            Servicos = new List<Servico>();
            FuncionariosComServicos = new List<FuncionariosComServicos>();
            ValidarInformacoes(razaoSocial, nomeFantasia, email, senha, cnpj);
            RazaoSocial = razaoSocial;
            NomeFantasia = nomeFantasia;
            Email = email;
            Senha = senha;
            CNPJ = cnpj;
            Endereco = new EnderecoDaEmpresa(cep);
        }
        private Empresa AdicionarRepositorio(RepositorioEmpresa repositorioEmpresa)
        {
            _repositorioEmpresa = repositorioEmpresa;
            return this;
        }

        public bool ValidarEmpresaExistente(RepositorioEmpresa repositorioEmpresa)
        {
            AdicionarRepositorio(repositorioEmpresa);
            if (_repositorioEmpresa.BuscarEmpresaPorCNPJ(CNPJ) != null) return true;
            return false;
        }

        public void ValidarInformacoes(string razaoSocial, string nomeFantasia, string email, string senha, string cnpj)
        {
            if (string.IsNullOrWhiteSpace(razaoSocial)) throw new Exception("A empresa deve ter uma Razao Social");
            if (string.IsNullOrWhiteSpace(nomeFantasia)) throw new Exception("A empresa deve ter um Nome Fantasia");
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("A empresa deve ter um email");
            if (string.IsNullOrWhiteSpace(senha)) throw new Exception("A empresa deve ter uma senha");
            if (string.IsNullOrWhiteSpace(cnpj) || !new CNPJValidator().IsValid(cnpj)) throw new Exception("A empresa deve ter um CNPJ valido");
        }
    }
}