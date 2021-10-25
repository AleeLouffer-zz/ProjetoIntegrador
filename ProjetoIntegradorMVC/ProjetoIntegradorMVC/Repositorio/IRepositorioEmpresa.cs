using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;

namespace ProjetoIntegradorMVC.Repositorio
{
    public interface IRepositorioEmpresa
    {
       Empresa BuscarEmpresaPorCNPJ(string cnpj);
       void AdicionarEmpresa(Empresa empresa);
       void VincularServico(string cnpj, Servico servico);
       void VincularFuncionario(string cnpj, Funcionario funcionario);
    }
}