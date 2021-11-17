using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioAgendamento : BaseRepositorio<Agendamento>, IRepositorioAgendamento
    {
        public RepositorioAgendamento(Contexto contexto) : base(contexto) { }

        public Agendamento BuscarAgendamentoPorClienteEServicoEDataEHora(Cliente cliente, Servico servico, DateTime HoraEData)
        {
            return _contexto.Set<Agendamento>().Where(agendamento => agendamento.Cliente.Nome == cliente.Nome && agendamento.Servico.Nome == servico.Nome && agendamento.HoraEData == HoraEData).SingleOrDefault();
        }

        public void AdicionarAgendamento(List<Agendamento> agendamentos)
        {
            foreach (var agendamento in agendamentos)
            {
                Adicionar(agendamento);
            } 
        }
    }
}