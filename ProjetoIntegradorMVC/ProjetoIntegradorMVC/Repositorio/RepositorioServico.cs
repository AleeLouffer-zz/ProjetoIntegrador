using Caelum.Stella.CSharp.Vault;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioServico : BaseRepositorio<Servico>, IRepositorioServico
    {
        public RepositorioServico(Contexto contexto) : base(contexto) { }

        public Servico BuscarServicoPorNomeEPreco(string nome, decimal preco) => _contexto.Set<Servico>().Where(servico => servico.Nome == nome && servico.Preco == preco).SingleOrDefault();

        public void AdicionarServicos(List<Servico> servicos)
        {
            foreach (var servico in servicos) Adicionar(servico);
            _contexto.SaveChanges();
        }

        public List<Servico> FiltrarPorTexto(string busca)
        {
            var servicos = BuscarTodos();

            return servicos = servicos.Where(servico =>
                servico.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase) ||
                busca.Contains(servico.Nome, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}
