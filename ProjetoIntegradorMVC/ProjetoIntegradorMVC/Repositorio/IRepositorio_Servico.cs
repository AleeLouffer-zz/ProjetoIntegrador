﻿using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorio_Servico
    {
        List<Servico> GetServicos();
        Servico GetServico(int id);
        void AddServicos(List<Servico> servicos);
        public bool VerificarServicoExistente(Servico servico);
    }
}