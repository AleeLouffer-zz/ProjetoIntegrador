using System;

namespace ProjetoIntegradorMVC.Excecoes
{
    public class CEPInvalidoException : Exception
    {
        public CEPInvalidoException (string mensagem) : base(mensagem) { }
        
    }
}
