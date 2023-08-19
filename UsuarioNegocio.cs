using System;
using System.Data;
using Entidade;
using DAO;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public void Incluir(UsuarioEntidade usu)
        {
            if (usu.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do usuario é obrigatório!!!");
            }
            if (usu.Cargo.Trim().Length == 0)
            {
                throw new Exception("O nome do cargo é obrigatório!!!");
            }
            if (usu.Login.Trim().Length == 0)
            {
                throw new Exception("O nome de login é obrigatório!!!");
            }
            if (usu.Senha.Trim().Length == 0)
            {
                throw new Exception("A senha é obrigatória!!!");
            }
            if (usu.Permissao.Trim().Length == 0)
            {
                throw new Exception("O nome da permissao é obrigatório!!!");
            }


            UsuarioDAO obj = new UsuarioDAO();
            obj.Incluir(usu);
        }
        public void Alterar(UsuarioEntidade usu)
        {
            if (usu.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do usuario é obrigatório!!!");
            }
            if (usu.Cargo.Trim().Length == 0)
            {
                throw new Exception("O nome do cargo é obrigatório!!!");
            }
            if (usu.Login.Trim().Length == 0)
            {
                throw new Exception("O nome de login é obrigatório!!!");
            }
            if (usu.Senha.Trim().Length == 0)
            {
                throw new Exception("A senha é obrigatória!!!");
            }
            if (usu.Permissao.Trim().Length == 0)
            {
                throw new Exception("O nome da permissao é obrigatório!!!");
            }


            UsuarioDAO obj = new UsuarioDAO();
            obj.Alterar(usu);

        }
        public void Excluir(int codigo)
        {
            if (codigo < 1)
            {
                throw new Exception("Selecione um usuário antes de excluí-lo");
            }

            UsuarioDAO obj = new UsuarioDAO();
            obj.Exluir(codigo);
        }
        public DataTable Listagem(string filtro)
        {
            UsuarioDAO obj = new UsuarioDAO();
            return obj.Listagem(filtro);
        }
    }
}