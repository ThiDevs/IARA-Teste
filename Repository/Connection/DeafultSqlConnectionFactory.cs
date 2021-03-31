using System.Data;
using System.Data.SqlClient;
using Repository.Contracts;

namespace Repository.Connection
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword");
        }
    }
}
