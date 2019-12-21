using BookLibrary.Domain.Models;
using System.Collections.Generic;

namespace BookLibrary.BLL.Interfaces
{
    public interface IReaderService
    {
        Reader Get(int id);

        IEnumerable<Reader> Get();

        void Add(Reader reader);

        void Update(Reader reader);

        void Remove(int id);
    }
}
