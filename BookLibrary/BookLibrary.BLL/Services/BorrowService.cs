using System;
using System.Collections.Generic;
using BookLibrary.BLL.Interfaces;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;

namespace BookLibrary.BLL.Services
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowsRepository _borrowsRepository;

        public BorrowService(IBorrowsRepository borrowsRepository)
        {
            _borrowsRepository = borrowsRepository;
        }

        public void Add(Borrow borrow)
        {
            _borrowsRepository.Create(borrow);
        }

        public Borrow Get(int id)
        {
            var borrow = _borrowsRepository.Get(id);

            return borrow;
        }

        public IEnumerable<Borrow> Get()
        {
            var borrows = _borrowsRepository.Get();

            return borrows;
        }

        public void Remove(int id)
        {
            var borrow = _borrowsRepository.Get(id);
            if (borrow == null)
            {
                throw new InvalidOperationException("Wrong id");
            }

            _borrowsRepository.Delete(borrow.BorrowId);
        }

        public void Update(Borrow borrow)
        {
            _borrowsRepository.Edit(borrow);
        }
    }
}
