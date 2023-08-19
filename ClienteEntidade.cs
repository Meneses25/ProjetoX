using System;

namespace Entidade
{
    public class ClienteEntidade
    {
        /// representa o campo CLI_CODIGO da tabela tbCliente
        public int? Codigo { get; set; }

        /// representa o campo CLI_NOME da tabela tbCliente
        public String Nome { get; set; }

        /// representa o campo CLI_CPF da tabela tbCliente
        public String CPF { get; set; }

        /// representa o campo CLI_ENDERECO da tabela tbCliente

        public String Endereco { get; set; }

        /// representa o campo CLI_TELEFONE da tabela tbCliente
        public String Telefone { get; set; }

        /// representa o campo CLI_EMAIL da tabela tbCliente
        public String EMAIL { get; set; }
    }
}
