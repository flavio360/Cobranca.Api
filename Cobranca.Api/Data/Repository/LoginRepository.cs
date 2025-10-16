using Cobranca.Api.Data.Infra;
using Cobranca.Api.Data.Interface;
using Cobranca.Api.Exceptions;
using Cobranca.Api.Models.Seguranca;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Cobranca.Api.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private IConnection _connection;

        public LoginRepository(IConnection connection)
        {
            _connection = connection;

        }
        public async Task<LoginModelRetorno> Autenticacao(string login)
        {
            _connection.Connect.ConnectionString = _connection.Connect.ConnectionString.Replace("Impacto_Cobranca_Prod", "Impacto_Cobranca_Users_Prod");
            try
            {
                var proc = Cobranca.Api.Data.Common.Procedures.Proc_p_User_Autenticattion;
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter
                {
                    ParameterName = "@Json",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = login
                });

                var result =  DataBase<LoginModelRetorno>.Instance.ExecuteReader(_connection.Connect.ConnectionString, proc, parameters);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Problema na execução da consulta");
            }
        }
    }
}
