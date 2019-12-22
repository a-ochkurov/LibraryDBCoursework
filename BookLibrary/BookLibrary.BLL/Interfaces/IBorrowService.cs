using BookLibrary.Domain.Models;
using System.Collections.Generic;

namespace BookLibrary.BLL.Interfaces
{
    public interface IBorrowService 
    {
        Borrow Get(int id);

        IEnumerable<Borrow> Get();

        void Add(Borrow borrow);

        void Update(Borrow borrow);

        void Remove(int id);
    }
}
