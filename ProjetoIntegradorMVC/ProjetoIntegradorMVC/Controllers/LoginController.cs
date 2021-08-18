using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradorMVC.Models.DAL;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            List<int> ids = new() { 1, 2 };
            var ids2 = new GenericDao<Cliente>().BuscarPorId(ids);
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if (ValidarLogin(email, senha))
            {
                return RedirectToRoute("Home/Index");
            }
            return View();
        }
        private bool ValidarLogin(string email, string senha)
        {
            string usuario = null; //contexto.DbSet;
            if (usuario == null) return false;
            return true;
        }
    }
}
