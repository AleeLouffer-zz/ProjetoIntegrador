using ProjetoIntegradorMVC.Models.ContextoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Repositorio;
using ProjetoIntegradorMVC.Models.LigaçãoModels;

namespace ProjetoIntegradorMVC
{
    public class InicializadorDB
    {

        private readonly Contexto _contexto;
        private readonly IRepositorio_Funcionario _repositorioFuncionario;
        private readonly IRepositorio_Servico _repositorioServico;
        private readonly IRepositorio_FuncionariosComServicos _repositorioFuncComServicos;

        public InicializadorDB(Contexto contexto, IRepositorio_Funcionario repositorioFuncionario, IRepositorio_Servico repositorioServico, IRepositorio_FuncionariosComServicos repositorioFuncComServicos)
        {
            _contexto = contexto;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioServico = repositorioServico;
            _repositorioFuncComServicos = repositorioFuncComServicos;
        }

        public void IniciarDB()
        {
            _contexto.Database.Migrate();
            List<Funcionario> funcionarios = SetFuncionarios();
            List<Servico> servicos = SetServicos(funcionarios);           

            _repositorioFuncionario.AddFuncionarios(funcionarios);
            _repositorioServico.AddServicos(servicos);

            List<FuncionariosComServicos> funcComServicos = SetFuncionariosComServicos(funcionarios, servicos);
            SaveFuncionariosComServicos(funcComServicos);
        }

        private void SaveFuncionariosComServicos(List<FuncionariosComServicos> funcComServicos)
        {
            foreach (var funcComServico in funcComServicos)
            {
                _repositorioFuncComServicos.SaveFuncionariosComServicos(funcComServico);
            }
        }

        private static List<FuncionariosComServicos> SetFuncionariosComServicos(List<Funcionario> funcionarios, List<Servico> servicos)
        {
            var funcComServicos = new List<FuncionariosComServicos>();
            
            for (int i = 0; i < 3; i++)
            {
                foreach (var servico in servicos)
                {
                    funcComServicos.Add(new FuncionariosComServicos(funcionarios[i], servico));
                }
            }
            
            return funcComServicos;
        }

        private static List<Servico> SetServicos(List<Funcionario> funcionarios)
        {
            return new List<Servico>() {
                new Servico("Corte Simples Cabelo", "Corte Simples", 15m),
                new Servico("Manicure", "Manicure", 999m),
                new Servico("Barba Grande", "Barba Grande", 200m)
            };
        }

        private static List<Funcionario> SetFuncionarios()
        {
            return new List<Funcionario>() {
                new Funcionario("Cleide", "111.111.111-11"),
                new Funcionario("Ravona", "222.222.222-22"),
                new Funcionario("Peggy", "333.333.333.-33")
            };
        }
    }
}
