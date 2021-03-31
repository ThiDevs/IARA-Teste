using System.Data;
using System.Data.SqlClient;
using Repository.Contracts;

namespace Repository.Connection
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Database=IaraDB;Data Source=(localdb)\\MSSQLLocalDB;");
        }
    }
}
