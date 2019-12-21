using BookLibrary.Domain.Models;
using System.Collections.Generic;

namespace BookLibrary.BLL.Interfaces
{
    public interface IAuthorService
    {
        Author Get(int id);

        IEnumerable<Author> Get();

        void Add(Author author);

        void Update(Author author);

        void Remove(int id);
    }
}
