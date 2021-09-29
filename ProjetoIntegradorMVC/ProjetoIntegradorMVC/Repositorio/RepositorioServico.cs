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
    public class RepositorioServico : IRepositorioServico
    {
        private readonly Contexto _contexto;

        public RepositorioServico(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<Servico> BuscarServicos() => _contexto.Set<Servico>().ToList();

        public Servico BuscarServicoPorId(int id) => _contexto.Set<Servico>().Where(servico => servico.Id == id).SingleOrDefault();

        public void AdicionarServicos(List<Servico> servicos)
        {
            foreach (var servico in servicos)
            {
                if (VerificarServicoExistente(servico)) throw new DuplicateNameException("O serviço já existe");
                _contexto.Set<Servico>().Add(servico);
            }
            _contexto.SaveChanges();
        }

        public bool VerificarServicoExistente (Servico servico)
        {
            return BuscarServicoPorNomeEPreco(servico.Nome, servico.Preco) != null;
        }

        public Servico BuscarServicoPorNomeEPreco(string nome, decimal preco)
        {
            return _contexto.Set<Servico>().Where(servico => servico.Nome == nome 
                                                    && servico.Preco == preco).SingleOrDefault();
        }
    }
}
