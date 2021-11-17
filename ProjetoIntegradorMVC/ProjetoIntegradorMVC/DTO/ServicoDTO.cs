using ProjetoIntegradorMVC.Models.Operacoes;
using ProjetoIntegradorMVC.Models.Usuarios;
using System.Collections.Generic;

namespace ProjetoIntegradorMVC.DTO
{
    public class ServicoDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int TempoEstimado { get; set; }
        public Local Local { get; set; }
        public ServicoDTO(Servico servico)
        {
            Nome = servico.Nome;
            Descricao = servico.Descricao; 
            Preco = servico.Preco;
            EmpresaId = servico.EmpresaId;
            Empresa = servico.Empresa;
            TempoEstimado = servico.TempoEstimado; 
            Local = servico.Local;
        }
    }
}
