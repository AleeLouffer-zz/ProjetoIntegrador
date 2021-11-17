using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegradorMVC.DTO
{
    public class ServicoDTO
    {
        public string NomeDoServico { get; set; }
        public decimal PrecoDoServico { get; set; }
        public string DescricaoDoServico { get; set; }
        public string NomeEmpresaDoServico { get; set; }

        private ServicoDTO() { }
        public ServicoDTO(Servico servico)
        {
            NomeDoServico = servico.Nome;
            PrecoDoServico = servico.Preco;
            DescricaoDoServico = servico.Descricao;
            NomeEmpresaDoServico = servico.Empresa.NomeFantasia;
        }
    }
}
