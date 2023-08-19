using System.Data;
using Entidade;
using System.Data.SqlClient;
using System;
using System.Collections;

namespace DAO
{
    public class TesteDAO
    {
        public void Incluir(TesteEntidade teste) {
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
                pnome.Value = teste.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pdescricao = new SqlParameter("@descricao", SqlDbType.NVarChar, 100);
                pdescricao.Value = teste.Descricao;
                cmd.Parameters.Add(pdescricao);

                conn.Open();
                cmd.ExecuteNonQuery();

                teste.Codigo = (Int32)cmd.Parameters["@codigo"].Value;
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
        public void Alterar(TesteEntidade teste)
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
                pcodigo.Value = teste.Codigo;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = teste.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pdescricao = new SqlParameter("@descricao", SqlDbType.NVarChar, 100);
                pdescricao.Value = teste.Descricao;
                cmd.Parameters.Add(pdescricao);

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

                if(restultado != 1)
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
