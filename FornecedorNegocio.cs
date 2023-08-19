using System;
using System.Data;
using Entidade;
using DAO;

namespace Negocio
{
    public class FornecedorNegocio
    {
        public void Incluir(FornecedorEntidade fornecedor)
        {
            if (fornecedor.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do teste é obrigatório!!!");
            }

            fornecedor.Endereco = fornecedor.Endereco.ToUpper();

            FornecedorDAO obj = new FornecedorDAO();
            obj.Incluir(fornecedor);
        }
        public void Alterar(FornecedorEntidade fornecedor)
        {
            if (fornecedor.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do teste é obrigatório!!!");
            }

            fornecedor.Endereco = fornecedor.Endereco.ToUpper();

            FornecedorDAO obj = new FornecedorDAO();
            obj.Alterar(fornecedor);

        }
        public void Excluir(int codigo)
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um teste antes de excluí-lo");
            }

            FornecedorDAO obj = new FornecedorDAO();
            obj.Exluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            FornecedorDAO obj = new FornecedorDAO();
            return obj.Listagem(filtro);
        }
    }
}