using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorio_Servico 
    {
        public Servico GetServico(int id);
        List<Servico> GetServicos();
        void AddServicos(List<Servico> servicos);
    }
}