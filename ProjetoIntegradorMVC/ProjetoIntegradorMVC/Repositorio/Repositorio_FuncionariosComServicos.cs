using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class Repositorio_FuncionariosComServicos : IRepositorio_FuncionariosComServicos
    {
        private readonly Contexto _contexto;

        public Repositorio_FuncionariosComServicos(Contexto contexto)
        {
            _contexto = contexto;

        }

        public void SaveFuncionariosComServicos(FuncionariosComServicos funcionariosComServicos)
        {
            _contexto.Set<FuncionariosComServicos>().Add(funcionariosComServicos);
            
            _contexto.SaveChanges();
        }

        public List<int> ListarFuncionariosID(int idServico)
        {
            var servicos = _contexto.Set<FuncionariosComServicos>().Where(s => s.IdServico == idServico).ToList();           
            
            var idFuncionarios = new List<int>();
            foreach (var servico in servicos)
            {
                idFuncionarios.Add(servico.IdFuncionario);
            }

            return idFuncionarios;
        }
    }
}
