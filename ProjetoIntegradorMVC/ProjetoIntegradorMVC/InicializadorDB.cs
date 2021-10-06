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
        private readonly IRepositorioCliente _repositorioCliente;

        public InicializadorDB(Contexto contexto, IRepositorioFuncionario repositorioFuncionario, IRepositorioServico repositorioServico, IRepositorioFuncionariosComServicos repositorioFuncComServicos, IRepositorioCliente repositorioCliente)
        {
            _contexto = contexto;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioServico = repositorioServico;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _repositorioCliente = repositorioCliente;
        }

        public void IniciarDB()
        {
            _contexto.Database.Migrate();
            List<Funcionario> funcionarios = SetFuncionarios();
            List<Servico> servicos = SetServicos();
            List<Cliente> cliente = SetClientes();

            _repositorioFuncionario.AdicionarFuncionarios(funcionarios);
            _repositorioServico.AdicionarServicos(servicos);
            _repositorioCliente.AdicionarClientes(cliente);

            List<FuncionariosComServicos> funcionariosComServicos = _repositorioFuncComServicos.VincularFuncionariosComServicos(funcionarios, servicos);
            _repositorioFuncComServicos.AdicionarFuncionariosComServicos(funcionariosComServicos);
        }

        private static List<Servico> SetServicos()
        {
            return new List<Servico>() {
                new Servico("Corte de Cabelo", "Corte Simples Cabelo", 15m),
                new Servico("Manicure", "Manicure", 999m),
                new Servico("Barba Grande", "Barba Grande", 200m)
            };
        }

        private static List<Funcionario> SetFuncionarios()
        {
            var diasDeTrabalho = new List<DiaDeTrabalho> { new DiaDeTrabalho("Segunda"), new DiaDeTrabalho("Terca"), new DiaDeTrabalho("Quarta"), new DiaDeTrabalho("Quinta"), new DiaDeTrabalho("Sexta") };
            var horariosDeTrabalho = new List<HorarioDeTrabalho> { new HorarioDeTrabalho("08:00"), new HorarioDeTrabalho("12:00"), new HorarioDeTrabalho("13:00"), new HorarioDeTrabalho("17:00") };
            var jornada = new JornadaDeTrabalho(diasDeTrabalho, horariosDeTrabalho);
            return new List<Funcionario>() {
                new Funcionario("Cleide", "cleide@hotmail.com", "123", "2412321311", jornada),
                new Funcionario("Ravona", "ravona@hotmail.com", "123", "2412321312", jornada),
                new Funcionario("Peggy" ,"peggy@hotmail.com", "123", "2412321313", jornada)
            };
        }

        private static List<Cliente> SetClientes()
        {
               return new List<Cliente>() {
               new Cliente("Jessica", "jessica@hotmail.com", "jessicalindona", "06064104147"),
               new Cliente("Carlos", "carlos@gmail.com", "carlao", "11122233345"),
               new Cliente("João Pedro", "pedrinho@hotmail.com", "joao123","33344455567" )
            };
        }
    }
}
