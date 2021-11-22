using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradorMVC.DTO;
using ProjetoIntegradorMVC.Models.Usuarios;
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
        private readonly IRepositorioEmpresa _repositorioEmpresa;
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        private readonly IRepositorioFuncionariosComServicos _repositorioFuncComServicos;
        private readonly IBuscador _buscador;

        public HomeController(IRepositorioServico repositorioServico,
            IRepositorioEmpresa repositorioEmpresa,
            IRepositorioFuncionario repositorioFuncionario,
            IRepositorioFuncionariosComServicos repositorioFuncComServicos,
            IBuscador buscador)
        {
            _repositorioServico = repositorioServico;
            _repositorioEmpresa = repositorioEmpresa;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _buscador = buscador;
        }

        public IActionResult Home()
        {
            return View(_repositorioServico.BuscarTodos());
        }

        public IActionResult Empresas(string busca)
        {
            //Guardar a string de busca
            HttpContext.Session.SetString("textoBusca", busca);
            //Filtrar empresas com nome parecido com buscador
            var empresasFiltradas = _repositorioEmpresa.FiltrarPorTexto(busca);
            //Montar o DTO das empresas
            var dtoEmpresas = new List<EmpresaDTO>();

            foreach (var empresa in empresasFiltradas)
            {
                dtoEmpresas.Add(new EmpresaDTO
                {
                    RazaoSocial = empresa.RazaoSocial,
                    Nome =  empresa.NomeFantasia,
                    CNPJ = empresa.CNPJ,
                    Endereco = empresa.Endereco
                });
            }
            
            //Retornar a view com DTO
            return View(dtoEmpresas);
        }

        public IActionResult Servicos()
        {
            //Filtrar mesmo nome nos servicos do banco com o buscador
            var servicosFiltrados = _repositorioServico.FiltrarPorTexto(HttpContext.Session.GetString("textoBusca"));
            //Montar o DTO de servicos
            var dtoServicos = new List<ServicoDTO>();

            foreach (var servico in servicosFiltrados)
            {
                dtoServicos.Add(new ServicoDTO
                {
                    NomeDoServico = servico.Nome,
                    PrecoDoServico = servico.Preco,
                    DescricaoDoServico = servico.Descricao,
                });
            }
            //Retornar a view com DTO
            return View(dtoServicos);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
