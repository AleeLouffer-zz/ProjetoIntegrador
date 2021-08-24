using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Repositorio.Interface;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Repositorio
{
    public class RepositorioAgendamentos : RepositorioBase<Agendamentos> , IRepositorioAgendamentos
    {
        public RepositorioAgendamentos(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}