using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioEmpresa : BaseRepositorio<Empresa>, IRepositorioEmpresa
    {
        public RepositorioEmpresa(Contexto contexto) : base(contexto) { }

        public Empresa BuscarEmpresaPorCNPJ(string cnpj) => _contexto.Set<Empresa>().Where(empresa => empresa.CNPJ == cnpj).SingleOrDefault();

        public void AdicionarEmpresa(Empresa empresa)
        {
            Adicionar(empresa);
        }

        public void VincularServico(string cnpj, Servico servico)
        {
            var empresa = BuscarEmpresaPorCNPJ(cnpj);
            if (empresa == null) throw new Exception("Empresa não encontrada");

            empresa.Servicos.Add(servico);
            _contexto.SaveChanges();
        }

        public void VincularFuncionario(string cnpj, Funcionario funcionario)
        {
            var empresa = BuscarEmpresaPorCNPJ(cnpj);
            if (empresa == null) throw new Exception("Empresa não encontrada");

            empresa.Funcionarios.Add(funcionario);
            _contexto.SaveChanges();
        }

        public List<Empresa> FiltrarPorTexto(string busca)
        {
            var empresas = this.BuscarTodos();

            return empresas = empresas.Where(empresa =>
                empresa.NomeFantasia.Contains(busca, StringComparison.OrdinalIgnoreCase) ||
                busca.Contains(empresa.NomeFantasia, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}