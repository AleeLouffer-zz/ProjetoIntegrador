using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Repositorio;
using ProjetoIntegradorMVC.Aplicacoes;

namespace ProjetoIntegradorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioServico _repositorioServico;
        private readonly IRepositorioFuncionario _repositorioFuncionario;
        private readonly IRepositorioFuncionariosComServicos _repositorioFuncComServicos;
        private readonly Contexto _contexto;
        private readonly IDetalhesDoServico _detalhesDoServico;

        public HomeController(IRepositorioServico repositorioServico, 
            IRepositorioFuncionario repositorioFuncionario, 
            IRepositorioFuncionariosComServicos repositorioFuncComServicos,
            Contexto contexto,
            IDetalhesDoServico detalhesDoServico)
        {
            _repositorioServico = repositorioServico;
            _repositorioFuncionario = repositorioFuncionario;
            _repositorioFuncComServicos = repositorioFuncComServicos;
            _contexto = contexto;
            _detalhesDoServico = detalhesDoServico;
        }

        public IActionResult PaginaInicial()
        {
            return View();
        }

        public IActionResult CatalogoDeServicos()
        {
            var servicos = _repositorioServico.ObterTodos();
            return View(servicos);
        }

        public IActionResult DetalhesDoServico(int id)
        {
            var DTO = _detalhesDoServico.BuscarInformacoesDoServicoSelecionado(id);
            return View(DTO);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
