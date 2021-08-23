using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjetoIntegradorMVC.Models.DAL
{
    public class Conexao 
    {
        public string ObterString() => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjetoIntegrador;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}