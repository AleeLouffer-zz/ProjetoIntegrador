using Microsoft.AspNetCore.Mvc;
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
