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
            var servicosDoBanco = _contexto.Set<Servico>().ToList();

            foreach (var servicoDoBanco in servicosDoBanco)
            {
                if (servicoDoBanco.Preco == servico.Preco &&
                    servicoDoBanco.Nome == servico.Nome) return true;
            }
            return false;
        }
    }
}
