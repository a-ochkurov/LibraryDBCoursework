using BookLibrary.BLL.Interfaces;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;
using System;
using System.Collections.Generic;

namespace BookLibrary.BLL.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IReadersRepository _readersRepository;

        public ReaderService(IReadersRepository readersRepository)
        {
            _readersRepository = readersRepository;
        }
        public void Add(Reader reader)
        {
            _readersRepository.Create(reader);
        }

        public Reader Get(int id)
        {
            var reader = _readersRepository.Get(id);

            return reader;
        }

        public IEnumerable<Reader> Get()
        {
            var readers = _readersRepository.Get();

            return readers;
        }

        public void Remove(int id)
        {
            var reader = _readersRepository.Get(id);
            if (reader == null)
            {
                throw new InvalidOperationException("Wrong id");
            }

            _readersRepository.Delete(reader.ReaderId);
        }

        public void Update(Reader reader)
        {
            _readersRepository.Edit(reader);
        }
    }
}
