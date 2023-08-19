
using System;

namespace Entidade
{
    public class UsuarioEntidade
    {
        /// representa o campo USU_CODIGO da tabela tbUsuario
        public int? Codigo { get; set; }

        /// representa o campo USU_NOME da tabela tbUsuario
        public String Nome { get; set; }

        /// representa o campo USU_CARGO da tabela tbUsuario
        public String Cargo { get; set; }

        /// representa o campo USU_LOGIN da tabela tbUsuario
        public String Login { get; set; }

        /// representa o campo USU_SENHA da tabela tbUsuario
        public String Senha { get; set; }

        /// representa o campo USU_PERMISSAO da tabela tbUsuario
        public String Permissao { get; set; }
    }
}

