using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoIntegradorMVC.Models.Operacoes
{
    [Table("Servico")]
    [Index(nameof(Nome), IsUnique = true)]
    [Index(nameof(Preco), IsUnique = true)]
    public class Servico : ClasseBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public Empresa Empresa { get; private set; }
        public int TempoEstimado { get; private set; }
        public Local Local { get; set; }
        
        private Servico(){ }

        public Servico(string nome, string descricao, decimal preco, Empresa empresa, Local local, int tempoEstimado = 0)
        {
            ValidarInformacoes(nome, descricao, preco, tempoEstimado);
            Nome = nome;
            Descricao = descricao;
            Preco = preco; 
            Empresa = empresa;
            TempoEstimado = tempoEstimado;
            Local = local;
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