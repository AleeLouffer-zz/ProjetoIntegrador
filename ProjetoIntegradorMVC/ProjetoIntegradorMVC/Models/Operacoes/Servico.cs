using Caelum.Stella.CSharp.Vault;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    [Table("Servico")]
    public class Servico : ClasseBase
    {
        private RepositorioServico _repositorioServico;
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int TempoEstimado { get; private set; }
        public Local Local { get; set; }

        private Servico(){ }
        public Servico(string nome, string descricao, decimal preco, int tempoEstimado, Local local)
        {
            ValidarInformacoes(nome, descricao, preco, tempoEstimado);
            Nome = nome;
            Descricao = descricao; 
            Preco = preco;
            TempoEstimado = tempoEstimado;
            Local = local;
        }

        private Servico AdicionarRepositorio(RepositorioServico repositorioServico)
        {
            _repositorioServico = repositorioServico;
            return this;
        }

        public bool ValidarServicoExistente(RepositorioServico repositorioServico)
        {
            AdicionarRepositorio(repositorioServico);
            if (_repositorioServico.BuscarServicoPorNomeEPreco(Nome, Preco) != null) return true;
            return false;
        }

        public void ValidarInformacoes(string nome, string descricao, decimal preco, int tempoEstimado)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("O serviço deve ter um nome");
            if (string.IsNullOrWhiteSpace(descricao)) throw new Exception("O serviço deve ter uma descrição");
            if (preco <= 0) throw new Exception("O serviço deve ter um preço");
            if (tempoEstimado < 0) throw new Exception("O tempo estimado é menor que 0 minutos");
        }
    }
}