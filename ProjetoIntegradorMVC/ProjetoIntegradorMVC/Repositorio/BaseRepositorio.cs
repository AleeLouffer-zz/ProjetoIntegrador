using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Repositorio
{
    public abstract class BaseRepositorio<T> : IBaseRepositorio<T> where T : ClasseBase
    {
        protected readonly Contexto _contexto;

        protected BaseRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public T BuscarPorId(int id) => _contexto.Set<T>().Where(t => t.Id == id).SingleOrDefault();

        public List<T> BuscarTodos() => _contexto.Set<T>().ToList();

        public void Adicionar(T objeto)
        {
            try
            {
                _contexto.Set<T>().Add(objeto);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException innerExeption = ex.InnerException as SqlException;
                if(innerExeption.Number == 2627 || innerExeption.Number == 2601) throw new DbUpdateException("Deu ruim no Banco");
            }
        }
    }
}