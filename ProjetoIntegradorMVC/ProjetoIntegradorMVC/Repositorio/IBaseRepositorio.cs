using ProjetoIntegradorMVC.Models;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IBaseRepositorio<T> where T : ClasseBase
    {
        List<T> Buscar();
    }
}