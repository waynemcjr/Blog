using Blog.API.Data;
using Microsoft.Data.SqlClient;

namespace Blog.API.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;

        public RoleRepository(ConnectionDB connection)
        {
            _connection = connection.GetConnection();
        }
    }
}
