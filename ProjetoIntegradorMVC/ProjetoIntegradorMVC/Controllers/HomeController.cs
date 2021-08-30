using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoIntegradorMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Controllers
{
    public class HomeController : Controller
    {
        FirebaseAuthProvider auth;
        public HomeController()
        {
            auth = new FirebaseAuthProvider(
                new FirebaseConfig("AIzaSyDNvkwh8PVLSHyIDwm-3ejgzBqYrq-7PSk"));
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            await auth.CreateUserWithEmailAndPasswordAsync(usuario.Email, usuario.Senha);

            var fbAuthLink = await auth
                .SignInWithEmailAndPasswordAsync(usuario.Email, usuario.Senha);
            string token = fbAuthLink.FirebaseToken;

            if (token != null)
            {
                HttpContext.Session.SetString("_userToken", token);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            var fbAuthLink = await auth
                .SignInWithEmailAndPasswordAsync(usuario.Email, usuario.Senha);
            string token = fbAuthLink.FirebaseToken;

            if (token != null)
            {
                HttpContext.Session.SetString("_userToken", token);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("_userToken");
            if (token != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
