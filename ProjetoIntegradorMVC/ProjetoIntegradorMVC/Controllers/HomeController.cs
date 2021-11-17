using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;
using ProjetoIntegradorMVC.Servicos;
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

        public HomeController(IRepositorioServico repositorioServico,
            IRepositorioFuncionario repositorioFuncionario,
            IRepositorioFuncionariosComServicos repositorioFuncComServicos)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioFuncComServicos = repositorioFuncComServicos;
        }

        public IActionResult Home()
        {
            return View(_repositorioServico.BuscarTodos());
        }

        public IActionResult Servico(int id)
        {
             var servicoDTO = _repositorioServico.BuscarPorId(id);
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
