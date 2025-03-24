using System.Data;
using Microsoft.Data.SqlClient;
using Modelo;

namespace DAL
{
    public class ClientesDAL
    {
        public void Incluir(ClienteInformation cliente)
        {
            //carrega a string de conexão do SQL Server
            SqlConnection cn = new SqlConnection();
            try
            {
                //carrega a string de conexão do SQL Server
                cn.ConnectionString = Dados.StringDeConexao();
                //cria objeto cmd para executar comandos
                SqlCommand cmd = new SqlCommand();
                //cmd recebe a string de conexão
                cmd.Connection = cn;
                //define que usaremos Stored Procedure do SQL Server
                cmd.CommandType = CommandType.StoredProcedure;
                //nome da Stored Procedure que será usada
                cmd.CommandText = "insere_cliente";
                //parâmetros da Stored Procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = ParameterDirection.Output;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.NVarChar, 100);
                pemail.Value = ParameterDirection.Output;
                cmd.Parameters.Add(pemail);

                SqlParameter Ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 80);
                Ptelefone.Value = ParameterDirection.Output;
                cmd.Parameters.Add(Ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();

                cliente.Codigo = (Int32)cmd.Parameters["@codigo"].Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Alterar(ClienteInformation cliente)
        {
            //carrega a string de conexão do SQL Server
            SqlConnection cn = new SqlConnection();
            try
            {
                //carrega a string de conexão do SQL Server
                cn.ConnectionString = "Data Source=DESKTOP-RG947R7;Initial Catalog=LOJINHA;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
                //cria objeto cmd para executar comandos
                SqlCommand cmd = new SqlCommand();
                //cmd recebe a string de conexão
                cmd.Connection = cn;
                //define que usaremos Stored Procedure do SQL Server
                cmd.CommandType = CommandType.StoredProcedure;
                //nome da Stored Procedure que será usada
                cmd.CommandText = "altera_cliente";
                //parâmetros da Stored Procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pcodigo);

                SqlParameter pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100);
                pnome.Value = cliente.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pemail = new SqlParameter("@email", SqlDbType.NVarChar, 100);
                pemail.Value = cliente.Email;
                cmd.Parameters.Add(pemail);

                SqlParameter ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 80);
                ptelefone.Value = cliente.Telefone;
                cmd.Parameters.Add(ptelefone);
                cn.Open();
                cmd.ExecuteNonQuery();

                cliente.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void Excluir(int codigo)
        {
            //carrega a string de conexão do SQL Server
            SqlConnection cn = new SqlConnection();
            try
            {
                //carrega a string de conexão do SQL Server
                cn.ConnectionString = Dados.StringDeConexao();
                //cria objeto cmd para executar comandos
                SqlCommand cmd = new SqlCommand();

                //cmd recebe a string de conexão
                cmd.Connection = cn;

                //define que usaremos Stored Procedure do SQL Server
                cmd.CommandType = CommandType.StoredProcedure;

                //nome da Stored Procedure que será usada
                cmd.CommandText = "exclui_cliente";

                //parâmetros da Stored Procedure
                SqlParameter pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = codigo;
                cmd.Parameters.Add(pcodigo);

                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente " + codigo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable Listagem(string filtro)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao();
                //adapter
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "seleciona_cliente";
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //Paramêtrops
                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@filtro", SqlDbType.Text);
                pfiltro.Value = filtro;

                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Servidor SQL Erro: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
