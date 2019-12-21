using BookLibrary.Domain.Models;
using System.Collections.Generic;

namespace BookLibrary.BLL.Interfaces
{
    public interface IGenreService
    {
        Genre Get(int id);

        IEnumerable<Genre> Get();

        void Add(Genre genre);

        void Update(Genre genre);

        void Remove(int id);
    }
}
