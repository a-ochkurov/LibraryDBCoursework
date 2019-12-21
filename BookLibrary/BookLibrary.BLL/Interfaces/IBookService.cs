using BookLibrary.Domain.Models;
using System.Collections.Generic;

namespace BookLibrary.BLL.Interfaces
{
    public interface IBookService
    {
        Book Get(int id);

        IEnumerable<Book> Get();

        void Add(Book book);

        void Update(Book book);

        void Remove(int id);
    }
}
