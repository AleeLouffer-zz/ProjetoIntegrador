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
    public class Repositorio_Servico : BaseRepositorio<Servico>, IRepositorioServico
    {
        public Repositorio_Servico(Contexto contexto) : base(contexto) { }

        public List<Servico> BuscarServicos() => _contexto.Set<Servico>().ToList();

        public Servico BuscarServicoPorId(int id) => _contexto.Set<Servico>().Where(servico => servico.Id == id).SingleOrDefault();

        public void AdicionarServicos(List<Servico> servicos)
        {
            foreach (var servico in servicos)
            {
                if (VerificarSeExisteNoBanco(servico)) throw new DuplicateNameException("O serviço já existe");
                Adicionar(servico);
            }
            _contexto.SaveChanges();
        }

        public override bool ExisteNoBanco(Servico servico )
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
