using System.Data;
using Entidade;
using System.Data.SqlClient;
using System;
using System.Collections;

namespace DAO
{
    public class UsuarioDAO
    {
        public void Incluir(UsuarioEntidade usuario)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsereUsuario";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = usuario.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pcargo = new SqlParameter("@cargo", SqlDbType.NVarChar, 100);
                pcargo.Value = usuario.Cargo;
                cmd.Parameters.Add(pcargo);

                SqlParameter plogin = new SqlParameter("@login", SqlDbType.NVarChar, 100);
                plogin.Value = usuario.Login;
                cmd.Parameters.Add(plogin);

                SqlParameter psenha = new SqlParameter("@senha", SqlDbType.NVarChar, 100);
                psenha.Value = usuario.Senha;
                cmd.Parameters.Add(psenha);

                SqlParameter ppermissao = new SqlParameter("@permissao", SqlDbType.NVarChar, 100);
                ppermissao.Value = usuario.Permissao;
                cmd.Parameters.Add(ppermissao);

                conn.Open();
                cmd.ExecuteNonQuery();

                usuario.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void Alterar(UsuarioEntidade usu)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AlteraUsuario";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = usu.Codigo;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = usu.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pcargo = new SqlParameter("@cargo", SqlDbType.NVarChar, 100);
                pcargo.Value = usu.Cargo;
                cmd.Parameters.Add(pcargo);

                SqlParameter plogin = new SqlParameter("@login", SqlDbType.NVarChar, 100);
                plogin.Value = usu.Login;
                cmd.Parameters.Add(plogin);

                SqlParameter psenha = new SqlParameter("@senha", SqlDbType.NVarChar, 100);
                psenha.Value = usu.Senha;
                cmd.Parameters.Add(psenha);

                SqlParameter ppermissao = new SqlParameter("@permissao", SqlDbType.NVarChar, 100);
                ppermissao.Value = usu.Permissao;
                cmd.Parameters.Add(ppermissao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void Exluir(int codigo)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ExcluiUsuario";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = codigo;
                cmd.Parameters.Add(pcodigo);

                conn.Open();
                int restultado = cmd.ExecuteNonQuery();

                if (restultado != 1)
                {
                    throw new Exception("Não foi possivel excluir o usuario" + codigo);
                }
            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable Listagem(string filtro)
        {
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter dtAdp = new SqlDataAdapter();
            DataTable dtTable = new DataTable();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                dtAdp.SelectCommand = new SqlCommand();
                dtAdp.SelectCommand.CommandText = "SelecionaUsuario";
                dtAdp.SelectCommand.Connection = conn;

                dtAdp.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pfiltro;

                pfiltro = dtAdp.SelectCommand.Parameters.Add("@filtro", SqlDbType.Text);
                pfiltro.Value = filtro;

                dtAdp.Fill(dtTable);

                return dtTable;
            }

            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
