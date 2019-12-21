using BookLibrary.BLL.Interfaces;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookLibrary.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {   
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            if (book.ISBN.Length != 13)
            {
                throw new InvalidOperationException("Inappropriate ISBN");
            }

            _bookRepository.Create(book);
        }

        public IEnumerable<Book> Get()
        {
            return _bookRepository.Get();
        }

        public Book Get(int id)
        {
            return _bookRepository.Get(id);
        }

        public void Remove(int id)
        {
            _bookRepository.Delete(id);
        }

        public void Update(Book book)
        {
            if (book.ISBN.Length != 13)
            {
                throw new InvalidOperationException("Inappropriate ISBN");
            }

            _bookRepository.Edit(book);
        }
    }
}
