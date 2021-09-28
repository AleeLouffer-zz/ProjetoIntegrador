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
            List<Servico> servicos = SetServicos();           

            _repositorioFuncionario.AddFuncionarios(funcionarios);
            _repositorioServico.AddServicos(servicos);

            List<FuncionariosComServicos> funcComServicos = _repositorioFuncComServicos.VincularFuncionariosComServicos(funcionarios, servicos);
            _repositorioFuncComServicos.AddFuncionariosComServicos(funcComServicos);
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
