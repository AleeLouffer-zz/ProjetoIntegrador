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

        public void AddFuncionarioComServico(FuncionariosComServicos funcionariosComServicos)
        {
            _contexto.Set<FuncionariosComServicos>().Add(funcionariosComServicos);
            
            _contexto.SaveChanges();
        }

        public void AddFuncionariosComServicos(List<FuncionariosComServicos> funcionariosComServicos)
        {

            foreach (var funcionarioComServico in funcionariosComServicos)
            {
                AddFuncionarioComServico(funcionarioComServico);
            }

            _contexto.SaveChanges();
        }

        public List<int> ListarIdsFuncionariosPelaIDServico(int idServico)
        {
            var servicos = _contexto.Set<FuncionariosComServicos>().Where(s => s.ServicoId == idServico).ToList();

            var idFuncionarios = new List<int>();
            foreach (var servico in servicos)
            {
                idFuncionarios.Add(servico.FuncionarioId);
            }

            return idFuncionarios;
        }

        public List<FuncionariosComServicos> VincularFuncionariosComServicos(List<Funcionario> funcionarios, List<Servico> servicos)
        {
            var funcComServicos = new List<FuncionariosComServicos>();

            var qtdFuncionarios = funcionarios.Count;

            for (int i = 0; i < qtdFuncionarios; i++)
            {
                foreach (var servico in servicos)
                {
                    funcComServicos.Add(new FuncionariosComServicos(funcionarios[i], servico));
                }
            }

            return funcComServicos;
        }
    }
}
