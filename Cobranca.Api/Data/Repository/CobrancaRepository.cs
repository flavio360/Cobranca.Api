using Cobranca.Api.Data.Infra;
using Cobranca.Api.Data.Interface;
using Cobranca.Api.Models;
using System.Data.SqlClient;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cobranca.Api.Data.Repository
{
    public class CobrancaRepository : ICobrancaRepository
    {
        private IConnection _connection;

        public CobrancaRepository(IConnection connection)
        {
            _connection = connection;

        }
        public async Task<(bool,string)> InsereNovaCobranca(OrigemModel novaOrigem)
        {
            try
            {
                var jsonParam = JsonSerializer.Serialize(novaOrigem, new JsonSerializerOptions { WriteIndented = true });
                var proc = Cobranca.Api.Data.Common.Procedures.Proc_p_Origem_Insert;
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter { ParameterName = "@JsonInput", Value = jsonParam });

                var result = await DataBase<(bool,string)>.Instance.ExecuteNonQueryAsync(_connection.Connect.ConnectionString, proc, parameters);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
