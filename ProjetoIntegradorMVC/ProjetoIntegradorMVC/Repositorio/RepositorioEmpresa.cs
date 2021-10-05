using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProjetoIntegradorMVC.Repositorio
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly Contexto _contexto;

        public RepositorioEmpresa(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Empresa BuscarEmpresaPorCNPJ(string cnpj) => _contexto.Set<Empresa>().Where(empresa => empresa.CNPJ == cnpj).SingleOrDefault();
        public bool VerificarSeEmpresaExiste(string cnpj) => BuscarEmpresaPorCNPJ(cnpj) != null;

        public void AdicionarEmpresa(Empresa empresa)
        {
            if (VerificarSeEmpresaExiste(empresa.CNPJ)) throw new DuplicateNameException("A Empresa já existe");

            _contexto.Set<Empresa>().Add(empresa);
            _contexto.SaveChanges();
        }

        public void VincularServico(string cnpj, Servico servico)
        {           
            if (!VerificarSeEmpresaExiste(cnpj)) throw new Exception("Empresa não encontrada");

            var empresa = BuscarEmpresaPorCNPJ(cnpj);
            empresa.Servicos.Add(servico);
            _contexto.SaveChanges();
        }

        public void VincularFuncionario(string cnpj, Funcionario funcionario)
        {
            if (!VerificarSeEmpresaExiste(cnpj)) throw new Exception("Empresa não encontrada");

            var empresa = BuscarEmpresaPorCNPJ(cnpj);
            empresa.Funcionarios.Add(funcionario);
            _contexto.SaveChanges();
        }
    }
}