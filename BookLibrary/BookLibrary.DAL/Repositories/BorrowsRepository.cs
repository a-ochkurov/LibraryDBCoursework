using BookLibrary.DAL.DbContext;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookLibrary.DAL.Repositories
{
    public class BorrowsRepository : IBorrowsRepository
    {
        private readonly IDbConnection _connection;

        public BorrowsRepository(LibraryDbContext dbContext)
        {
            _connection = dbContext.Connection;
        }

        public void Create(Borrow entity)
        {
            var sql = "INSERT [dbo].[borrows] ([ReaderId], [BookId], [TakenDate], [BroughtDate]) " +
            "VALUES(@ReaderId, @BookId, @TakenDate, @BroughtDate)";

            entity.BorrowId = _connection.ExecuteScalar<int>(sql, entity);
        }

        public void Delete(int id)
        {
            var sql = "DELETE FROM borrows WHERE BorrowId = @Id";

            _connection.Execute(sql, new { Id = id });
        }

        public void Edit(Borrow entity)
        {
            var sql = "UPDATE [dbo].[borrows] SET [TakenDate] = @TakenDate, [BroughtDate] = @BroughtDate WHERE [BorrowId]  = @BorrowId";

            _connection.Execute(sql, entity);
        }

        public Borrow Get(int id)
        {
            var sql = "SELECT * FROM borrows WHERE BorrowId = @Id";
            var borrow = _connection.Query<Borrow>(sql, new { Id = id }).FirstOrDefault();

            return borrow;
        }

        public IEnumerable<Borrow> Get()
        {
            var sql = "SELECT * FROM borrows";
            var borrows = _connection.Query<Borrow>(sql);

            return borrows;
        }
    }
}
