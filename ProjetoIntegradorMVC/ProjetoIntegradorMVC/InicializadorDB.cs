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
            _contexto.Database.EnsureDeleted();
            _contexto.Database.EnsureCreated();

            Empresa empresa = CriarEmpresa();
            List<Funcionario> funcionarios = CriarFuncionarios(empresa);
            List<Servico> servicos = CriarServicos(empresa);
            List<Cliente> clientes = CriarClientes();
            List<Agendamento> agendamentos = CriarAgendamentos( empresa, funcionarios[0], clientes[0], servicos[0]);

            _repositorioEmpresa.AdicionarEmpresa(empresa);
            _repositorioFuncionario.AdicionarFuncionarios(funcionarios);
            _repositorioServico.AdicionarServicos(servicos);
            _repositorioCliente.AdicionarClientes(clientes);
            _repositorioAgendamento.AdicionarAgendamentos(agendamentos);

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

        private static Empresa CriarEmpresa()
        {
            return new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
        }

        private static List<Servico> CriarServicos(Empresa empresa)
        {
            return new List<Servico>() {
                new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m, empresa, Local.ADomicilio),
                new Servico("Manicure", "Manicure", 999m, empresa, Local.Ambos),
                new Servico("Barba Grande", "Barba Grande", 200m, empresa, Local.ADomicilio)
            };
        }

        private static List<Funcionario> CriarFuncionarios(Empresa empresa)
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

        private static List<Cliente> CriarClientes()
        {
            return new List<Cliente>() {
               new Cliente("Jessica", "jessica@hotmail.com", "jessicalindona", "06064104147"),
               new Cliente("Carlos", "carlos@gmail.com", "carlao", "85526580032"),
               new Cliente("João Pedro", "pedrinho@hotmail.com", "joao123","05806188035" )
            };
        }
        
        private static List<Agendamento> CriarAgendamentos(Empresa empresa,Funcionario funcionario, Cliente cliente, Servico servico)
        {
            return new List<Agendamento>(){
                new Agendamento(funcionario, empresa, servico, new DateTime(2001,12,12,14,00,00), cliente)
            };
        }
    }
}
