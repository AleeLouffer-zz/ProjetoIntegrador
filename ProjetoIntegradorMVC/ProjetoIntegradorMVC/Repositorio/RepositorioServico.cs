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

        public void AdicionarServicos(List<Servico> servicos)
        {
            foreach (var servico in servicos)
            {
                if (servico.ExisteNoBanco(this)) throw new DuplicateNameException("O serviço já existe");
                AdicionarUm(servico);
            }

            _contexto.SaveChanges();
        }

        public Servico BuscarServicoPorNomeEPreco(string nome, decimal preco)
        {
            return _contexto.Set<Servico>().Where(servico => servico.Nome == nome 
                                                    && servico.Preco == preco).SingleOrDefault();
        }
    }
}
