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

        public InicializadorDB(Contexto contexto, IRepositorioFuncionario repositorioFuncionario, IRepositorioServico repositorioServico, IRepositorioFuncionariosComServicos repositorioFuncComServicos, IRepositorioEmpresa repositorioEmpresa)
        {
            _contexto = contexto;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioServico = repositorioServico;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _repositorioEmpresa = repositorioEmpresa;
        }

        public void IniciarDB()
        {
            _contexto.Database.Migrate();

            Empresa empresa = SetEmpresa();
            List<Funcionario> funcionarios = SetFuncionarios();
            List<Servico> servicos = SetServicos();

            _repositorioEmpresa.AdicionarEmpresa(empresa);
            _repositorioFuncionario.AdicionarFuncionarios(funcionarios);
            _repositorioServico.AdicionarServicos(servicos);

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
            var  jornada = new  JornadaDeTrabalho (diasDeTrabalho, horariosDeTrabalho);
            return new List<Funcionario>() {
                new Funcionario("Cleide", "cleide@hotmail.com", "123", "2412321311", jornada),
                new Funcionario("Ravona", "ravona@hotmail.com", "123", "2412321312", jornada),
                new Funcionario("Peggy" ,"peggy@hotmail.com", "123", "2412321313", jornada)
            };
        }
    }
}
