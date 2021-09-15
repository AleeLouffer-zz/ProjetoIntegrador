using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio_Servico _repositorioServico;
        private readonly IRepositorio_Funcionario _repositorioFuncionario;
        private readonly IRepositorio_FuncionarioServico _repositorioFuncComServicos;

        public HomeController(IRepositorio_Servico repositorioServico, IRepositorio_Funcionario repositorioFuncionario, IRepositorio_FuncionarioServico repositorioFuncComServicos)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioFuncComServicos = repositorioFuncComServicos;
        }

        public IActionResult Home()
        {
            return View(_repositorioServico.GetServicos());
        }

        public IActionResult Servico(int id)
        {
             var servicoDTO = _repositorioServico.GetServico(id);
             var idsFuncionario = _repositorioFuncComServicos.ListarIdsFuncionariosPelaIDServico(id);
             var funcionarios = _repositorioFuncionario.GetFuncionarios(idsFuncionario);

             var DTO = new DTOServicos(servicoDTO, funcionarios);
             return View(DTO);
        }
    }
}
