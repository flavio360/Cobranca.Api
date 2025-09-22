using System.Data.SqlClient;

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
    }
}
