﻿using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
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

        public HomeController(IRepositorioServico repositorioServico, IRepositorioFuncionario repositorioFuncionario, IRepositorioFuncionariosComServicos repositorioFuncComServicos,
            Contexto contexto)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _contexto = contexto;
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
    
        public IActionResult Empresas(string busca)
        {
            var empresas = _contexto.Set<Empresa>().ToList();

            if (!string.IsNullOrEmpty(busca))
            {
                empresas = empresas.Where(e => 
                    e.NomeFantasia.Contains(busca, StringComparison.OrdinalIgnoreCase) ||
                    busca.Contains(e.NomeFantasia, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            return View(empresas);
        }
    }
}
