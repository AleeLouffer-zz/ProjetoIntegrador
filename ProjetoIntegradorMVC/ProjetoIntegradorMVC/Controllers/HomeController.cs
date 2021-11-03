using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioServico _repositorioServico;
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        private readonly IRepositorioFuncionariosComServicos _repositorioFuncComServicos;
        private readonly Contexto _contexto;

        public HomeController(IRepositorioServico repositorioServico, 
            IRepositorioFuncionario repositorioFuncionario, 
            IRepositorioFuncionariosComServicos repositorioFuncComServicos,
            Contexto contexto)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _contexto = contexto;
        }

        public IActionResult PaginaInicial()
        {
            return View();
        }

        public IActionResult CatalogoDeServicos()
        {
            var servicos = _repositorioServico.Buscar();
            return View(servicos);
        }

        public IActionResult DetalhesDoServico(int id)
        {
            var servicoDTO = _repositorioServico.BuscarPorID(id);
            var idsFuncionario = _repositorioFuncComServicos.BuscarIdsDosFuncionariosPeloIdDoServico(id);
            var funcionarios = _repositorioFuncionario.BuscarFuncionariosPorIds(idsFuncionario);

            var DTO = new ServicoDTO(servicoDTO, funcionarios);
            return View(DTO);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
