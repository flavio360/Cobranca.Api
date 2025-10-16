using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Cobranca.Api.Data.Infra
{
    public class DataBase<T>
    {
        public static DataBase<T> Instance { get;  } = new DataBase<T>();

        
        public async Task<(bool Condicao, string Mensagem)> ExecuteNonQueryAsync(string _ConnectionString, string commandText, List<SqlParameter> parameters)
        {
            var conexao = new SqlConnection(_ConnectionString);
            var cmd = new SqlCommand();
            cmd.CommandTimeout = 0;

            try
            {
                cmd.Connection = conexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = commandText;

                foreach (var item in parameters)
                    cmd.Parameters.Add(item);

                await conexao.OpenAsync();

                var linhasAfetadas = await cmd.ExecuteNonQueryAsync();

                if (linhasAfetadas > 0)
                {
                    return (true,"");
                }
                return (false,"Nenhum registro afetado");
            }
            catch (Exception ex)
            {

                return (false,"Erro: " + ex.Message);
            }
        }


        public async Task<T> ExecuteQueryAsync(string connectionString, string storedProcedure, object? parameters = null)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();


            var result = await connection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 500);

            return result.FirstOrDefault();
        }

        public List<T> ExecuteReader(string _ConnectionString, string CommandText, List<SqlParameter> parameters)
        {
            var conexao = new SqlConnection(_ConnectionString);
            var cmd = new SqlCommand();
            var list = new List<T>();

            SqlDataReader reader;

            try
            {
                cmd.Connection = conexao;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = CommandText;
                cmd.CommandTimeout = 0;

                foreach (var item in parameters)
                    cmd.Parameters.Add(item);

                conexao.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(Library.readTable<T>(reader));
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }

            return list;

        }


    }
}
