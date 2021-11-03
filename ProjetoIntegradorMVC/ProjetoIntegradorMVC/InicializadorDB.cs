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
using ProjetoIntegradorMVC.Models;

namespace ProjetoIntegradorMVC
{
    public class InicializadorDB
    {

        private readonly Contexto _contexto;
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        private readonly IRepositorioServico _repositorioServico;
        private readonly IRepositorioFuncionariosComServicos _repositorioFuncComServicos;
        private readonly IRepositorioEmpresa _repositorioEmpresa;
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioAgendamento _repositorioAgendamento;
        
        public InicializadorDB(Contexto contexto, IRepositorioFuncionario repositorioFuncionario, IRepositorioServico repositorioServico, IRepositorioFuncionariosComServicos repositorioFuncComServicos, IRepositorioCliente repositorioCliente, IRepositorioEmpresa repositorioEmpresa, IRepositorioAgendamento repositorioAgendamento)

        {
            _contexto = contexto;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioServico = repositorioServico;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _repositorioEmpresa = repositorioEmpresa;
            _repositorioCliente = repositorioCliente;
            _repositorioAgendamento = repositorioAgendamento;
        }

        public void IniciarDB()
        {
            _contexto.Database.Migrate();

            Empresa empresa = SetEmpresa();
            List<Funcionario> funcionarios = SetFuncionarios(empresa);
            List<Servico> servicos = SetServicos(empresa);
            List<Cliente> cliente = SetClientes();
            List<Agendamento> agendamentos = SetAgendamentos(empresa);

            _repositorioEmpresa.AdicionarEmpresa(empresa);
            _repositorioFuncionario.AdicionarFuncionarios(funcionarios);
            _repositorioServico.AdicionarServicos(servicos);
            _repositorioCliente.AdicionarClientes(cliente);
            _repositorioAgendamento.AdicionarAgendamento(agendamentos);

            foreach(var funcionario in funcionarios)
            {
                _repositorioEmpresa.VincularFuncionario(empresa.CNPJ, funcionario);
            }

            foreach (var servico in servicos)
            {
                _repositorioEmpresa.VincularServico(empresa.CNPJ, servico);
            }

            List <FuncionariosComServicos> funcionariosComServicos = _repositorioFuncComServicos.VincularFuncionariosComServicosDaEmpresa(funcionarios, servicos, empresa);
            _repositorioFuncComServicos.AdicionarFuncionariosComServicos(funcionariosComServicos);
        }

        private static Empresa SetEmpresa()
        {
            return new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
        }

        private static List<Servico> SetServicos(Empresa empresa)
        {
            return new List<Servico>() {
                new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m, empresa, Local.ADomicilio),
                new Servico("Manicure", "Manicure", 999m, empresa, Local.Ambos),
                new Servico("Barba Grande", "Barba Grande", 200m, empresa, Local.ADomicilio)
            };
        }

        private static List<Funcionario> SetFuncionarios(Empresa empresa)
        {
            var funcionarios = new List<Funcionario>() {
                new Funcionario("Cleide", "cleide@hotmail.com", "123", "11810292018", empresa),
                new Funcionario("Ravona", "ravona@hotmail.com", "123", "86390362099", empresa),
                new Funcionario("Peggy" ,"peggy@hotmail.com", "123", "14227481031", empresa)
            };

            foreach (var funcionario in funcionarios)
            {
                funcionario.AdicionarExpediente(DayOfWeek.Friday, "08:00", "18:00");
            };

            return funcionarios;
        }

        private static List<Cliente> SetClientes()
        {
            return new List<Cliente>() {
               new Cliente("Jessica", "jessica@hotmail.com", "jessicalindona", "06064104147"),
               new Cliente("Carlos", "carlos@gmail.com", "carlao", "85526580032"),
               new Cliente("João Pedro", "pedrinho@hotmail.com", "joao123","05806188035" )
            };
        }
        
        private static List<Agendamento> SetAgendamentos(Empresa empresa)
        {
            var funcionario = new Funcionario("Cleide", "cleide@hotmail.com", "123", "06297337160", empresa);
            var servico = new Servico("Vagabundo", "Corte de Cabelo", 90m, empresa, Local.NaEmpresa);
            var cliente = new Cliente("Kaique", "kaique@hotmail.com", "0112", "43144393860");
           
            return new List<Agendamento>(){
                new Agendamento(funcionario, empresa, servico, "12/12/2001 14:00:00", cliente)
            };
        }
    }
}
