using PI.Testes.Helpers;
using ProjetoIntegradorMVC.Models;
using ProjetoIntegradorMVC.Models.ContextoDb;
using ProjetoIntegradorMVC.Models.Usuarios;
using ProjetoIntegradorMVC.Repositorio;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Xunit;

namespace PI.Testes
{
    public class RepositorioClienteTeste
    {
        private readonly Contexto _contexto;
        private readonly RepositorioCliente _repositorioCliente;
        private readonly BancoDeDadosEmMemoriaAjudante _bancoDeDadosEmMemoriaAjudante;

        public RepositorioClienteTeste()
        {
            _bancoDeDadosEmMemoriaAjudante = new BancoDeDadosEmMemoriaAjudante();

            _contexto = _bancoDeDadosEmMemoriaAjudante.CriarContexto("DBTesteRepositorioCliente");

            _repositorioCliente = new RepositorioCliente(_contexto);
            _bancoDeDadosEmMemoriaAjudante.ReiniciaOBanco(_contexto);

        }

        [Fact]
        public void Deve_adicionar_os_clientes()
        {
            var cliente1 = new Cliente("Kaique", "kaique@hotmail.com", "0112", "43650100851");
            var cliente2 = new Cliente("Maria", "maria@gmail.com", "1912", "56615000172");
            var cliente3 = new Cliente("Carlos", "carlos@gmail.com", "4567", "06064104147");
            var cliente4 = new Cliente("Jean", "jean@gmail.com", "2233", "00207862125");
            var clientesASeremAdicionados = new List<Cliente>();
            var clientesRetornados = new List<Cliente>();
            clientesASeremAdicionados.Add(cliente1);
            clientesASeremAdicionados.Add(cliente2);
            clientesASeremAdicionados.Add(cliente3);
            clientesASeremAdicionados.Add(cliente4);

            _repositorioCliente.AdicionarClientes(clientesASeremAdicionados);

            foreach (var cliente in clientesASeremAdicionados)
            {
                clientesRetornados.Add(_repositorioCliente.BuscarClientePorCPF(cliente.CPF));
            }
            Assert.Equal(clientesASeremAdicionados, clientesRetornados);
        }

        [Fact]
        public void Nao_deve_adicionar_cliente_existente()
        {
            const string mensagemEsperada = "O cliente já existe.";
            var cliente = new Cliente("Jessica", "jessica@hotmail.com", "jessicalindona", "19043042811");
            var listaClientesExistentes = new List<Cliente> { cliente };
            _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();

            void Acao() => _repositorioCliente.AdicionarClientes(listaClientesExistentes);

            var mensagem = Assert.Throws<DuplicateNameException>(Acao).Message;
            Assert.Equal(mensagemEsperada, mensagem);
        }
    }
}