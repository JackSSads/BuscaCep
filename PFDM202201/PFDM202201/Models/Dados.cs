using System;
using System.Collections.Generic;
using System.Text;

namespace PFDM202201.Models
{
    internal class Dados
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public int ErroLogin { get; set; }

        public void InsertDados(string nome, string email, string senha, string confirmaSenha, int erroLogin)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.ConfirmaSenha = confirmaSenha;
            this.ErroLogin = erroLogin;
        }
    }
}
