using System;
using System.Data;
using Entidade;
using DAO;

namespace Negocio
{
    public class ProdutoNegocio
    {
        public void Incluir(ProdutoEntidade produto)
        {
            if(produto.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório!!!");
            }

            produto.Categoria = produto.Categoria.ToUpper();

            ProdutoDAO obj = new ProdutoDAO();
            obj.Incluir(produto);
        }
        public void Alterar(ProdutoEntidade produto)
        {
            if (produto.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório!!!");
            }

            produto.Categoria = produto.Categoria.ToUpper();

            ProdutoDAO obj = new ProdutoDAO();
            obj.Alterar(produto);

        }
        public void Excluir(int codigo)
        {
            if(codigo < 1)
            {
                throw new Exception("Selecione um produto antes de excluí-lo");
            }

            ProdutoDAO obj = new ProdutoDAO();
            obj.Exluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            ProdutoDAO obj = new ProdutoDAO();
            return obj.Listagem(filtro);
        }
    }
}