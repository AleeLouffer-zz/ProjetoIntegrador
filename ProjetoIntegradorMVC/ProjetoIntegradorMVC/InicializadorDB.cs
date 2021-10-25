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

        public InicializadorDB(Contexto contexto, IRepositorioFuncionario repositorioFuncionario, IRepositorioServico repositorioServico, IRepositorioFuncionariosComServicos repositorioFuncComServicos, IRepositorioCliente repositorioCliente, IRepositorioEmpresa repositorioEmpresa)

        {
            _contexto = contexto;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioServico = repositorioServico;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _repositorioEmpresa = repositorioEmpresa;
            _repositorioCliente = repositorioCliente;
        }

        public void IniciarDB()
        {
            _contexto.Database.Migrate();
          
            List<Funcionario> funcionarios = SetFuncionarios();
            List<Servico> servicos = SetServicos();
            List<Cliente> cliente = SetClientes();

            Empresa empresa = SetEmpresa();
            List<Funcionario> funcionarios = SetFuncionarios(empresa);
            _repositorioEmpresa.AdicionarEmpresa(empresa);

            List<Servico> servicos = SetServicos(empresa);
            _repositorioFuncionario.AdicionarFuncionarios(funcionarios);
            _repositorioServico.AdicionarServicos(servicos);
            _repositorioCliente.AdicionarClientes(cliente);

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
            var diasDeTrabalho = new List<DiaDaSemana> { new DiaDaSemana("Segunda"), new DiaDaSemana("Terca"), new DiaDaSemana("Quarta"), new DiaDaSemana("Quinta"), new DiaDaSemana("Sexta") };
            var horariosDeTrabalho = new List<Horario> { new Horario("08:00"), new Horario("12:00"), new Horario("13:00"), new Horario("17:00") };
            var  jornada = new  JornadaDeTrabalho (diasDeTrabalho, horariosDeTrabalho);
            return new List<Funcionario>() {
                new Funcionario("Cleide", "cleide@hotmail.com", "123", "11810292018", jornada, empresa),
                new Funcionario("Ravona", "ravona@hotmail.com", "123", "86390362099", jornada, empresa),
                new Funcionario("Peggy" ,"peggy@hotmail.com", "123", "86390362099", jornada, empresa)
            };
        }

        private static List<Cliente> SetClientes()
        {
               return new List<Cliente>() {
               new Cliente("Jessica", "jessica@hotmail.com", "jessicalindona", "06064104147"),
               new Cliente("Carlos", "carlos@gmail.com", "carlao", "85526580032"),
               new Cliente("João Pedro", "pedrinho@hotmail.com", "joao123","05806188035" )
            };
        }
    }
}
