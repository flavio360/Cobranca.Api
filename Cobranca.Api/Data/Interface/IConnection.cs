using System.Data.SqlClient;

namespace Cobranca.Api.Data.Interface
{
    public interface IConnection : IDisposable
    {
        SqlConnection Connect { get; }
        SqlConnection Open();
        void Close();
        SqlCommand CreateCommand();
    }
}
