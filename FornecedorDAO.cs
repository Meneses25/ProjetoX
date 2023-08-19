using System.Data;
using Entidade;
using System.Data.SqlClient;
using System;
using System.Collections;

namespace DAO
{
    public class FornecedorDAO
    {
        public void Incluir(FornecedorEntidade fornecedor)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsereFornecedor";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = fornecedor.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 100);
                ptelefone.Value = fornecedor.Telefone;
                cmd.Parameters.Add(ptelefone);

                SqlParameter pcnpj = new SqlParameter("@cnpj", SqlDbType.NVarChar, 100);
                pcnpj.Value = fornecedor.CNPJ;
                cmd.Parameters.Add(pcnpj);

                SqlParameter pendereco = new SqlParameter("@endereco", SqlDbType.NVarChar, 100);
                pendereco.Value = fornecedor.Endereco;
                cmd.Parameters.Add(pendereco);


                conn.Open();
                cmd.ExecuteNonQuery();

                fornecedor.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

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
        public void Alterar(FornecedorEntidade fornecedor)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = ConnectionFactory.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AlteraFornecedor";

                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = fornecedor.Codigo;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = fornecedor.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 100);
                ptelefone.Value = fornecedor.Telefone;
                cmd.Parameters.Add(ptelefone);

                SqlParameter pcnpj = new SqlParameter("@cnpj", SqlDbType.NVarChar, 100);
                pcnpj.Value = fornecedor.CNPJ;
                cmd.Parameters.Add(pcnpj);

                SqlParameter pendereco = new SqlParameter("@endereco", SqlDbType.NVarChar, 100);
                pendereco.Value = fornecedor.Endereco;
                cmd.Parameters.Add(pendereco);

                
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
                cmd.CommandText = "ExcluiFornecedor";

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
                dtAdp.SelectCommand.CommandText = "SelecionaFornecedor";
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
