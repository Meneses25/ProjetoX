using System;
using System.Data;
using Entidade;
using DAO;

namespace Negocio
{
    public class TesteNegocio
    {
        public void Incluir(TesteEntidade teste)
        {
            if(teste.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do teste é obrigatório!!!");
            }

            teste.Descricao = teste.Descricao.ToUpper();

            TesteDAO obj = new TesteDAO();
            obj.Incluir(teste);
        }
        public void Alterar(TesteEntidade teste)
        {
            if (teste.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do teste é obrigatório!!!");
            }

            teste.Descricao = teste.Descricao.ToUpper();

            TesteDAO obj = new TesteDAO();
            obj.Alterar(teste);

        }
        public void Excluir(int codigo)
        {
            if(codigo < 1)
            {
                throw new Exception("Selecione um teste antes de excluí-lo");
            }

            TesteDAO obj = new TesteDAO();
            obj.Exluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            TesteDAO obj = new TesteDAO();
            return obj.Listagem(filtro);
        }
    }
}