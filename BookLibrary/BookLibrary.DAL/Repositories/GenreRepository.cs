using BookLibrary.DAL.DbContext;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookLibrary.DAL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IDbConnection _connection;

        public GenreRepository(LibraryDbContext dbContext)
        {
            _connection = dbContext.Connection;
        }

        public void Create(Genre entity)
        {
            var sql = "INSERT [dbo].[genres] ([GenreName]) " +
                        "VALUES(@GenreName)";

            entity.GenreId = _connection.ExecuteScalar<int>(sql, entity);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM genres WHERE GenreId = @Id";

            _connection.Execute(sql, new { Id = id });
        }

        public void Edit(Genre entity)
        {
            var sql = "UPDATE [dbo].[genres] SET [GenreName] = @GenreName WHERE [GenreId]  = @GenreId";

            _connection.Execute(sql, entity);
        }

        public Genre Get(int id)
        {
            var sql = "SELECT * FROM genres WHERE GenreId = @Id";
            var genre = _connection.Query<Genre>(sql, new { Id = id }).FirstOrDefault();

            return genre;
        }

        public IEnumerable<Genre> Get()
        {
            var sql = "SELECT * FROM genres";
            var genres = _connection.Query<Genre>(sql);

            return genres;
        }
    }
}
