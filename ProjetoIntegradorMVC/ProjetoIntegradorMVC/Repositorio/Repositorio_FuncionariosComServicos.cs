using Microsoft.EntityFrameworkCore;
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
        private readonly DbContext _contexto;

        public Repositorio_FuncionariosComServicos(DbContext contexto)
        {
            _contexto = contexto;
        }

        public void SaveFuncionariosComServicos(FuncionariosComServicos funcionariosComServicos)
        {
            _contexto.Set<FuncionariosComServicos>().Add(funcionariosComServicos);
            
            _contexto.SaveChanges();
        }

        public void SaveFuncionariosComServicos(List<FuncionariosComServicos> funcionariosComServicos)
        {

            foreach (var funcionarioComServico in funcionariosComServicos)
            {
                _contexto.Set<FuncionariosComServicos>().Add(funcionarioComServico);
            }

            _contexto.SaveChanges();
        }

        public List<int> ListarFuncionariosID(int idServico)
        {
            var servicos = _contexto.Set<FuncionariosComServicos>().Where(s => s.ServicoId == idServico).ToList();

            var idFuncionarios = new List<int>();
            foreach (var servico in servicos)
            {
                idFuncionarios.Add(servico.FuncionarioId);
            }

            return idFuncionarios;
        }
    }
}
