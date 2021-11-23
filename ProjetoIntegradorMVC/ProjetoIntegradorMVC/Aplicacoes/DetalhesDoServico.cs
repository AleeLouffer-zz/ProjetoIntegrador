using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Aplicacoes
{
    public class DetalhesDoServico : IDetalhesDoServico
    {
        private readonly IRepositorioServico _repositorioServico;
        private readonly IRepositorioFuncionariosComServicos _repositorioFuncionarioComServico;
        private readonly IRepositorioFuncionario _repositorioFuncionario;

        public DetalhesDoServico(IRepositorioServico repositorioServico, 
            IRepositorioFuncionariosComServicos repositorioFuncionarioComServico, 
            IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionarioComServico = repositorioFuncionarioComServico;
            _repositorioFuncionario = repositorioFuncionario;
        }

        public ServicoDTO BuscarInformacoesDoServicoSelecionado(int id)
        {
            var servico = _repositorioServico.BuscarPorID(id);
            var idsFuncionario = _repositorioFuncionarioComServico.BuscarIdsDosFuncionariosPeloIdDoServico(id);
            var funcionarios = _repositorioFuncionario.BuscarFuncionariosPorIds(idsFuncionario);

            var servicoDTO = new ServicoDTO {
                Nome = servico.Nome,
                Descricao = servico.Descricao,
                Preco = servico.Preco,
                EmpresaId = servico.EmpresaId,
                Empresa = servico.Empresa,
                TempoEstimado = servico.TempoEstimado,
                Local = servico.Local
            };

            foreach (var funcionario in funcionarios)
            {
                servicoDTO.Funcionarios.Add(new FuncionarioDTO {
                    Nome = funcionario.Nome,
                    CPF = funcionario.CPF,
                    Empresa = funcionario.Empresa,
                    EmpresaId = funcionario.EmpresaId,
                    Agendamentos = funcionario.Agendamentos,
                    ExpedientesDeTrabalho = funcionario.ExpedientesDeTrabalho
                });
            }

            return servicoDTO;
        }  
    }
}