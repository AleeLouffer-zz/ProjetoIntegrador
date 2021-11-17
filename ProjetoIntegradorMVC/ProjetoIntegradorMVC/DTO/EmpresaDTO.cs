using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.DTO
{
    public class EmpresaDTO
    {
        public string NomeDaEmpresa { get; set; }
        public string RuaDaEmpresa { get; set; }
        public string BairroDaEmpresa { get; set; }

        public EmpresaDTO(Empresa empresa)
        {
            NomeDaEmpresa = empresa.NomeFantasia;
            RuaDaEmpresa = empresa.Endereco.Localidade;
            BairroDaEmpresa = empresa.Endereco.Bairro;
        }
    }
}
