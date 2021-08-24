using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Repositorio.Interface;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Repositorio
{
    public class RepositorioPrestador : RepositorioBase<PrestadorDeServico> , IRepositorioPrestador
    {
        public RepositorioPrestador(bool SaveChanges = true) : base(SaveChanges)
        {

        }
    }
}