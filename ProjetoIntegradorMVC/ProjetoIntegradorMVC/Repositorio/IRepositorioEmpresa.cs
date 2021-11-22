using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioEmpresa : IBaseRepositorio<Empresa>
    {
       Empresa BuscarEmpresaPorCNPJ(string cnpj);
       void AdicionarEmpresa(Empresa empresa);
       void VincularServico(string cnpj, Servico servico);
       void VincularFuncionario(string cnpj, Funcionario funcionario);
       List<Empresa> FiltrarPorTexto(string busca);
    }
}