using BookLibrary.DAL.DbContext;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookLibrary.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _connection;

        public BookRepository(LibraryDbContext dbContext)
        {
            _connection = dbContext.Connection;
        }

        public void Create(Book entity)
        {
            var sql = "INSERT INTO Books(ISBN, Title, Author, EditionType, IsDeleted) VALUES(@ISBN, @Title, @Author, @EditionType, @IsDeleted); SELECT SCOPE_IDENTITY()";

            entity.BookId = _connection.ExecuteScalar<int>(sql, entity);
        }

        public void Edit(Book entity)
        {
            var sql = "UPDATE Books SET ISBN = @ISBN, Title = @Title, Author = @Author, EditionType = @EditionType WHERE BookId  = @Id";

            _connection.Execute(sql, entity);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Books WHERE Id = @Id";

            _connection.Execute(sql,new { Id = id });
        }

        public Book Get(int id)
        {
            var sql = "SELECT * FROM Books WHERE Id = @Id";

            return _connection.Query<Book>(sql, new { Id = id }).FirstOrDefault();
        }

        public IEnumerable<Book> Get()
        {
            var sql = "SELECT * FROM Books";

            return _connection.Query<Book>(sql).ToList();
        }
    }
}
