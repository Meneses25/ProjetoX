using System;

namespace Entidade
{
    public class FornecedorEntidade
    {
        /// representa o campo FOR_CODIGO da tabela tbForncedores
        public int? Codigo { get; set; }

        /// representa o campo FOR_RAZAOSOC da tabela tbForncedores
        public string Nome { get; set; }

        /// representa o campo FOR_TELEFONECOM da tabela tbForncedores
        public string Telefone { get; set; }

        /// representa o campo FOR_CNPJ da tabela tbForncedores
        public string CNPJ { get; set; }

        /// representa o campo FOR_ENDERECO da tabela tbForncedores
        public string Endereco { get; set; }
    }
}
