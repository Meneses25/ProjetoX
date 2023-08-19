using System;

namespace Entidade
{
    public class ProdutoEntidade
    {
        /// representa o campo PRO_CODIGO da tabela tbProduto
        public int? Codigo { get; set; }
        
        /// representa o campo PRO_NOME da tabela tbProduto
        public string Nome { get; set; }
        
        /// representa o campo PRO_CATEGORIA da tabela tbProduto
        public string Categoria { get; set; }
        
        /// representa o campo PRO_PRECO da tabela tbProduto
        public double Preco { get; set; }
        
        /// representa o campo PRO_ESTOQUE da tabela tbProduto
        public int Estoque { get; set; }
    }
}
