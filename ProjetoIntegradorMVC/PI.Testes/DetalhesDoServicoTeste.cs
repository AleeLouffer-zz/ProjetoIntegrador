using ExpectedObjects;
using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Aplicacoes;
using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PI.Testes
{
    public class DetalhesDoServicoTeste
    {
        private readonly Funcionario _funcionario;
        private readonly Servico _servico;
        private readonly Empresa _empresa;
        private DetalhesDoServico _detalhesDoServico;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;
        private readonly Contexto _contexto;
        private RepositorioServico _repositorioServico;
        private RepositorioFuncionariosComServicos _repositorioFuncionarioComServicos;
        private RepositorioFuncionario _repositorioFuncionario;
        private RepositorioEmpresa _repositorioEmpresa;


        public DetalhesDoServicoTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteDetalhesDoServico");
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

            _repositorioServico = new RepositorioServico(_contexto);
            _repositorioFuncionarioComServicos = new RepositorioFuncionariosComServicos(_contexto);
            _repositorioFuncionario = new RepositorioFuncionario(_contexto);
            _repositorioEmpresa = new RepositorioEmpresa(_contexto);
            _detalhesDoServico = new DetalhesDoServico(_repositorioServico, _repositorioFuncionarioComServicos, _repositorioFuncionario);

            _empresa = new Empresa("Inteligencia LTDA", "Inteligencia", "inteligencia@inteligencia.com.br", "12345", "05389493000117", "79004394");
            _funcionario = new Funcionario("Cleide", "cleide@cleide.com.br", "123", "85769390026", _empresa);
            _servico = new Servico("Corte", "Corte de Cabelo", 50m, _empresa, Local.ADomicilio);

            _repositorioEmpresa.AdicionarEmpresa(_empresa);
            _repositorioFuncionario.Adicionar(_funcionario);
            _repositorioServico.Adicionar(_servico);
            _repositorioFuncionarioComServicos.AdicionarFuncionariosComServicos(new FuncionariosComServicos(_funcionario, _servico, _empresa));
            _repositorioFuncionarioComServicos.VincularFuncionariosComServicosDaEmpresa( new List<Funcionario> { _funcionario } , new List<Servico> { _servico }, _empresa);
            _contexto.SaveChanges();
        }

        [Fact]
        public void DeveRetornarUmDTOServicos()
        {
            var servico = _repositorioServico.Buscar().FirstOrDefault();
            var idEsperada = servico.Id;
            var DTOEsperado = new ServicoDTO(_servico, new List<Funcionario> { _funcionario });

            var DTO = _detalhesDoServico.BuscarInformacoesDoServicoSelecionado(idEsperada);

            Assert.Equal (DTOEsperado.Funcionarios.SingleOrDefault(), DTO.Funcionarios.SingleOrDefault());
        }
    }
}
