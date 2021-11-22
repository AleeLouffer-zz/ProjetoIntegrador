using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.LigaçãoModels;
using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.DTO
{
    public class EmpresaDTO
    {
        public string RazaoSocial { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public EnderecoDaEmpresa Endereco { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public List<Servico> Servicos { get; set; }
        public List<FuncionariosComServicos> FuncionariosComServicos { get; set; }
    }
}
