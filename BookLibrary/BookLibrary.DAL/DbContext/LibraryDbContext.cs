using System.Data;
using System.Data.SqlClient;

namespace BookLibrary.DAL.DbContext
{
    public class LibraryDbContext
    {
        private readonly IDbConnection _connection;

        public IDbConnection Connection => _connection;

        public LibraryDbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }
    }
}
