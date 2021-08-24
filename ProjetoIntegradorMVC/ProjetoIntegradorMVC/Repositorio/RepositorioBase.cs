using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Models.Repositorio
{
    public class RepositorioBase<T> : IRepositorio<T>, IDisposable where T : class
    {
        protected Contexto _contexto;
        public bool _salvarAlteracoes = true;
        public RepositorioBase(bool salvarAlteracoes = true)
        {
            _salvarAlteracoes = salvarAlteracoes;
            _contexto = new Contexto();
        }
        public T Alterar(T objeto)
        {
            _contexto.Entry(objeto).State = EntityState.Modified;
            if (_salvarAlteracoes) _contexto.SaveChanges();
            return objeto;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public void Excluir(T objeto)
        {
            _contexto.Set<T>().Remove(objeto);
            if (_salvarAlteracoes) _contexto.SaveChanges();
        }

        public void Excluir(params object[] variavel)
        {
            var objeto = SelecionarPorId(variavel);
            Excluir(objeto);
        }

        public T Incluir(T objeto)
        {
            _contexto.Set<T>().Add(objeto);
            if (_salvarAlteracoes) _contexto.SaveChanges();
            return objeto;
        }

        public void SalvarAlteracoes()
        {
            _contexto.SaveChanges();
        }

        public T SelecionarPorId(params object[] variavel)
        {
            return _contexto.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _contexto.Set<T>().ToList();
        }
    }
}
