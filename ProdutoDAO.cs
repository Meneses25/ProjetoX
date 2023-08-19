using System.Data;
using Entidade;
using System.Data.SqlClient;
using System;

namespace DAO
{
    public class ProdutoDAO
    {
        public void Incluir(ProdutoEntidade produto)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsereTeste";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = produto.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pcategoria = new SqlParameter("@categoria", SqlDbType.NVarChar, 100);
                pnome.Value = produto.Categoria;
                cmd.Parameters.Add(pcategoria);

                SqlParameter ppreco = new SqlParameter("@preco", SqlDbType.Float, 100);
                pnome.Value = produto.Preco;
                cmd.Parameters.Add(ppreco);

                SqlParameter pestoque = new SqlParameter("@estoque", SqlDbType.Int, 100);
                pnome.Value = produto.Estoque;
                cmd.Parameters.Add(pestoque);

                conn.Open();
                cmd.ExecuteNonQuery();

                produto.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

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
        public void Alterar(ProdutoEntidade produto)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AlteraTeste";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = produto.Codigo;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = produto.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pcategoria = new SqlParameter("@categoria", SqlDbType.NVarChar, 100);
                pnome.Value = produto.Categoria;
                cmd.Parameters.Add(pcategoria);

                SqlParameter ppreco = new SqlParameter("@preco", SqlDbType.Float, 100);
                pnome.Value = produto.Preco;
                cmd.Parameters.Add(ppreco);

                SqlParameter pestoque = new SqlParameter("@estoque", SqlDbType.Int, 100);
                pnome.Value = produto.Estoque;
                cmd.Parameters.Add(pestoque);

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
                cmd.CommandText = "ExcluiTeste";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = codigo;
                cmd.Parameters.Add(pcodigo);

                conn.Open();
                int restultado = cmd.ExecuteNonQuery();

                if (restultado != 1)
                {
                    throw new Exception("Não foi possivel excluir o teste " + codigo);
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
                dtAdp.SelectCommand.CommandText = "SelecionaTeste";
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
