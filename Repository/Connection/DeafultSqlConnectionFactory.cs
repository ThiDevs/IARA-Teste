using System.Data;
using System.Data.SqlClient;
using Repository.Contracts;

namespace Repository.Connection
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=189.84.214.2;Database=PhidelisMonteiroLobato;User Id=usuariosga;Password=senha");
            //return new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword");
        }
    }
}
