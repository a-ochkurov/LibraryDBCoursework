using System;
using System.Collections.Generic;
using BookLibrary.BLL.Interfaces;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;

namespace BookLibrary.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorService(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public void Add(Author author)
        {
            _authorsRepository.Create(author);
        }

        public Author Get(int id)
        {
            var author = _authorsRepository.Get(id);

            return author;
        }

        public IEnumerable<Author> Get()
        {
            var authors = _authorsRepository.Get();

            return authors;
        }

        public void Remove(int id)
        {
            var author = _authorsRepository.Get(id);
            if (author == null)
            {
                throw new InvalidOperationException("Wrong id");
            }

            _authorsRepository.Delete(author.AuthorId);
        }

        public void Update(Author author)
        {
            _authorsRepository.Edit(author);
        }
    }
}
