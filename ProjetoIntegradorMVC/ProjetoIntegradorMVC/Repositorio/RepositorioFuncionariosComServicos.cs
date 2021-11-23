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
    public class RepositorioFuncionariosComServicos : IRepositorioFuncionariosComServicos
    {
        private readonly Contexto _contexto;

        public RepositorioFuncionariosComServicos(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void AdicionarFuncionariosComServicos(FuncionariosComServicos funcionariosComServicos)
        {
            _contexto.Set<FuncionariosComServicos>().Add(funcionariosComServicos);
            
            _contexto.SaveChanges();
        }

        public void AdicionarFuncionariosComServicos(List<FuncionariosComServicos> funcionariosComServicos)
        {

            foreach (var funcionarioComServico in funcionariosComServicos)
            {
                AdicionarFuncionariosComServicos(funcionarioComServico);
            }

            _contexto.SaveChanges();
        }

        public List<int> BuscarIdsDosFuncionariosPeloIdDoServico(int idServico)
        {
            var servicos = _contexto.Set<FuncionariosComServicos>().Where(funcionariosComServicos => funcionariosComServicos.ServicoId == idServico).ToList();

            var idFuncionarios = new List<int>();
            foreach (var servico in servicos)
            {
                idFuncionarios.Add(servico.FuncionarioId);
            }

            return idFuncionarios;
        }

        public List<FuncionariosComServicos> VincularFuncionariosComServicosDaEmpresa(List<Funcionario> funcionarios, List<Servico> servicos, Empresa empresa)
        {
            var funcionariosComServicos = new List<FuncionariosComServicos>();

            var quantidadeDeFuncionarios = funcionarios.Count;

            for (int i = 0; i < quantidadeDeFuncionarios; i++)
            {
                foreach (var servico in servicos)
                {
                    funcionariosComServicos.Add(new FuncionariosComServicos(funcionarios[i], servico, empresa));
                }
            }

            return funcionariosComServicos;
        }
    }
}
