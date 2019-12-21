using BookLibrary.DAL.DbContext;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookLibrary.DAL.Repositories
{
    public class ReadersRepository : IReadersRepository
    {
        private readonly IDbConnection _connection;

        public ReadersRepository(LibraryDbContext dbContext)
        {
            _connection = dbContext.Connection;
        }

        public void Create(Reader entity)
        {
            var sql = "INSERT [dbo].[readers] ([FirstName],[LastName]) " +
                       "VALUES(@FirstName, @LastName)";

            entity.ReaderId = _connection.ExecuteScalar<int>(sql, entity);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM readers WHERE ReaderId = @Id";

            _connection.Execute(sql, new { Id = id });
        }

        public void Edit(Reader entity)
        {
            var sql = "UPDATE [dbo].[readers] SET [FirstName] = @FirstName, [LastName] = @LastName WHERE [ReaderId]  = @ReaderId";

            _connection.Execute(sql, entity);
        }

        public Reader Get(int id)
        {
            var sql = "SELECT * FROM readers WHERE ReaderId = @Id";
            var reader = _connection.Query<Reader>(sql, new { Id = id }).FirstOrDefault();

            return reader;
        }

        public IEnumerable<Reader> Get()
        {
            var sql = "SELECT * FROM readers";
            var readers = _connection.Query<Reader>(sql);

            return readers;
        }
    }
}
