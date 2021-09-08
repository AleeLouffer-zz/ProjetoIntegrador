using Microsoft.EntityFrameworkCore;
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
    public class Repositorio_Servico : IRepositorio_Servico
    {
        private readonly Contexto _contexto;

        public Repositorio_Servico(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<Servico> GetServicos()
        {
            return _contexto.Set<Servico>().ToList();
        }
        public Servico GetServico(int id)
        {
            return _contexto.Set<Servico>().Where(s => s.Id == id).SingleOrDefault();
        }

        public void AddServicos(List<Servico> servicos)
        {
            foreach (var servico in servicos)
            {
                if (!VerificarServicoExistente(servico))
                {
                    _contexto.Set<Servico>().Add(servico);
                }
                
                throw new DuplicateNameException("O serviço já existe");
            }
            _contexto.SaveChanges();
        }

        public bool VerificarServicoExistente (Servico servico)
        {
            var servicosDoBanco = _contexto.Set<Servico>().ToList();
            
            foreach (var servicoDoBanco in servicosDoBanco)
            {
                if   (servico.Nome == servicoDoBanco.Nome &&
                   servico.Preco == servicoDoBanco.Preco) return true;
             }
            return false;
        }
    }
}
