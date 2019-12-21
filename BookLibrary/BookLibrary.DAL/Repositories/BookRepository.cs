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
            var sql = "INSERT [dbo].[books] ([bookId], [ISBN], [Title], [Comment], [Quantity], [Pages],[AuthorId],[GenreId]) VALUES(@BookId, @ISBN, @Title, @Comment, @Quantity, @Pages, @AuthorId, @GenreId)";

            entity.BookId = _connection.ExecuteScalar<int>(sql, entity);
        }

        public void Edit(Book entity)
        {
            var sql = "UPDATE [dbo].[books] SET [ISBN] = @ISBN, [Title] = @Title, [Comment] = @Comment, [Quantity] = @Quantity [Pages] = @Pages ,[AuthorId] = @AuthorId, [GenreId] = @GenreId  WHERE [BookId]  = @BookId";

            _connection.Execute(sql, entity);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM Books WHERE BookId = @Id";

            _connection.Execute(sql, new { Id = id });
        }

        public Book Get(int id)
        {
            var sql = "SELECT * FROM books WHERE BookId = @Id";
            var book = _connection.Query<Book>(sql, new { Id = id }).FirstOrDefault();

            return book;
        }

        public IEnumerable<Book> Get()
        {
            var sql = "SELECT * FROM books";
            var books = _connection.Query<Book>(sql);

            return books;
        }
    }
}
