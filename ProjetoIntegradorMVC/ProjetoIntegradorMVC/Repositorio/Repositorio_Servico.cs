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
    public class Repositorio_Servico : BaseRepositorio<Servico>, IRepositorio_Servico
    {
        public Repositorio_Servico(Contexto contexto) : base(contexto) { }

        public Servico GetServico(int id) => GetPorId(id);
        public List<Servico> GetServicos() => _contexto.Set<Servico>().ToList();

        public void AddServicos(List<Servico> servicos)
        {
            foreach (var servico in servicos)
            {
                if (VerificarSeExisteNoBanco(servico)) throw new DuplicateNameException("O serviço já existe");
                Adicionar(servico);
            }
            _contexto.SaveChanges();
        }

        public override bool ExisteNoBanco(Servico objetoNoBanco)
        {
            if (objetoNoBanco.Preco == objetoNoBanco.Preco &&
            objetoNoBanco.Nome == objetoNoBanco.Nome) return true;
            return false;
        }
    }
}
