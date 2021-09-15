using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ProjetoIntegradorMVC.Models.LigaçãoModels;

namespace PI.Testes
{
    public class RepositorioFuncionarioServicoTeste
    {
        private readonly Funcionario _funcionario;
        private readonly Servico _servico;
        private readonly Funcionario _funcionario2;
        private readonly Servico _servico2;
        private readonly Contexto _contexto;
        private readonly Repositorio_FuncionarioServico _repo;
        public RepositorioFuncionarioServicoTeste()
        {
            var options = new DbContextOptionsBuilder<Contexto>()
                .UseInMemoryDatabase(databaseName: "DBTesteFuncionariosComServicos")
                .Options;

            _contexto = new Contexto(options);
            _contexto.Database.EnsureDeleted();
            _contexto.Database.EnsureCreated();

            _repo = new Repositorio_FuncionarioServico(_contexto);

            _funcionario = new Funcionario("Cleide", "cleide@cleide.com.br", "123", "111.111.111-11");
            _funcionario2 = new Funcionario("Cleide", "cleide@cleide.com.br", "123", "112.111.111-11");
            _servico = new Servico("Corte", "Corte de Cabelo", "50,00");
            _servico2 = new Servico("Manicure", "Manicure", "30,00");
        }

        [Fact]
        public void Deve_adicionar_um_funcionario_com_servico()
        {
            var funcComServico = new FuncionarioServico(_funcionario, _servico);

            _repo.AddFuncionarioComServico(funcComServico);

            Assert.Equal(1, _contexto.FuncionarioServico.Count());
        }

        [Fact]
        public void Deve_adicionar_varios_funcionarios_com_servicos()
        { 

            var funcsComServicos = new List<FuncionarioServico> { new FuncionarioServico(_funcionario, _servico), new FuncionarioServico(_funcionario2, _servico2) };

            _repo.AddFuncionariosComServicos(funcsComServicos);

            Assert.Equal(2, _contexto.FuncionarioServico.Count());
        }

        [Fact]
        public void Deve_listar_ids_dos_funcionario_pela_id_de_servico()
        {
            var idEsperado = _contexto.Servicos.Where(a => a.Nome == "Corte").Select(a => a.Id).SingleOrDefault();
            var idsFuncionariosEsperados = _contexto.FuncionarioServico.Select(a => a.FuncionarioId).ToList();
            var idFuncionario = _repo.ListarIdsFuncionariosPelaIDServico(idEsperado);

            Assert.Equal(idsFuncionariosEsperados, idFuncionario);
        }

        [Fact]
        public void Deve_vincular_funcionario_com_servicos()
        {
            var funcionarios = new List<Funcionario> { _funcionario, _funcionario2 };
            var servicos = new List<Servico> { _servico, _servico2 };

            var funcionariosComServicos = _repo.VincularFuncionariosComServicos(funcionarios, servicos);

            Assert.Equal(4, funcionariosComServicos.Count());
        }
    }
}
