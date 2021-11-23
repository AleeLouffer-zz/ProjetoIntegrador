using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioAgendamento : IBaseRepositorio<Agendamento>
    {
        public Agendamento BuscarAgendamentoPorClienteEServicoEDataEHora(Cliente cliente, Servico servico, DateTime HoraEData);
        void AdicionarAgendamentos(List<Agendamento> agendamentos);
    }
}
