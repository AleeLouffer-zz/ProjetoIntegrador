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
        private readonly Cliente _cliente;
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
            _cliente = new Cliente("Jessica", "jessica@gmail.com", "123", "09746195077");
            _servico = new Servico("Corte", "Corte de Cabelo", 50m, _empresa, Local.ADomicilio);
            
            _repositorioEmpresa.AdicionarEmpresa(_empresa);
            _repositorioFuncionario.Adicionar(_funcionario);
            _repositorioServico.Adicionar(_servico);
            _repositorioFuncionarioComServicos.AdicionarFuncionariosComServicos(new FuncionariosComServicos(_funcionario, _servico, _empresa));
            _repositorioFuncionarioComServicos.VincularFuncionariosComServicosDaEmpresa( new List<Funcionario> { _funcionario } , new List<Servico> { _servico }, _empresa);
            _funcionario.Agendamentos.Add(new Agendamento(_funcionario, _empresa, _servico, "12/10/2021 14:00:00", _cliente));
            
            _contexto.SaveChanges();
            
        }

        [Fact]
        public void DeveRetornarUmDTOServicos()
        {
            var servico = _repositorioServico.BuscarServicoPorNomeEPreco("Corte", 50m);
            var idEsperada = servico.Id;
            var DTOEsperado = new FuncionarioEServicoDTO(new List<FuncionarioDTO> { new FuncionarioDTO(_funcionario) }, new ServicoDTO(_servico));

            var DTO = _detalhesDoServico.BuscarInformacoesDoServicoSelecionado(idEsperada);

            Assert.Equal (DTOEsperado.Funcionarios.SingleOrDefault().CPF, DTO.Funcionarios.SingleOrDefault().CPF);
        }
    }
}
