using BookLibrary.DAL.DbContext;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookLibrary.DAL.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly IDbConnection _connection;

        public AuthorsRepository(LibraryDbContext dbContext)
        {
            _connection = dbContext.Connection;
        }

        public void Create(Author entity)
        {
            var sql = "INSERT [dbo].[authors] ([AuthorId], [Name], [Surname]) " +
                "VALUES(@AuthorId, @Name, @Surname)";

            entity.AuthorId = _connection.ExecuteScalar<int>(sql, entity);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM authors WHERE AuthorId = @Id";

            _connection.Execute(sql, new { Id = id });
        }

        public void Edit(Author entity)
        {
            var sql = "UPDATE [dbo].[authors] SET [Name] = @Name, [Surname] = @Surname WHERE [AuthorId]  = @AuthorId";

            _connection.Execute(sql, entity);
        }

        public Author Get(int id)
        {
            var sql = "SELECT * FROM authors WHERE AuthorId = @Id";
            var author = _connection.Query<Author>(sql, new { Id = id }).FirstOrDefault();

            return author;
        }

        public IEnumerable<Author> Get()
        {
            var sql = "SELECT * FROM authors";
            var authors = _connection.Query<Author>(sql);

            return authors;
        }
    }
}
