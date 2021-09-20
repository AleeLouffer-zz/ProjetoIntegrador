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
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        private readonly IRepositorioServico _repositorioServico;
        private readonly IRepositorioFuncionariosComServicos _repositorioFuncComServicos;

        public InicializadorDB(Contexto contexto, IRepositorioFuncionario repositorioFuncionario, IRepositorioServico repositorioServico, IRepositorioFuncionariosComServicos repositorioFuncComServicos)
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
            List<Servico> servicos = SetServicos();           

            _repositorioFuncionario.Adicionarfuncionarios(funcionarios);
            _repositorioServico.AdicionarServicos(servicos);

            List<FuncionariosComServicos> funcionariosComServicos = _repositorioFuncComServicos.VincularFuncionariosComServicos(funcionarios, servicos);
            _repositorioFuncComServicos.AdicionarFuncionariosComServicos(funcionariosComServicos);
        }

        private static List<Servico> SetServicos()
        {
            return new List<Servico>() {
                new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m),
                new Servico("Manicure", "Manicure",999m),
                new Servico("Barba Grande", "Barba Grande", 200m)
            };
        }

        private static List<Funcionario> SetFuncionarios()
        {
            return new List<Funcionario>() {
                new Funcionario("Cleide", "cleide@hotmail.com", "123", "2412321311"),
                new Funcionario("Ravona", "ravona@hotmail.com", "123", "2412321312"),
                new Funcionario("Peggy" ,"peggy@hotmail.com", "123", "2412321313")
            };
        }
    }
}
