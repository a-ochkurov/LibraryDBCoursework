using System;
using System.Collections.Generic;
using BookLibrary.BLL.Interfaces;
using BookLibrary.DAL.Interfaces;
using BookLibrary.Domain.Models;

namespace BookLibrary.BLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public void Add(Genre genre)
        {
            _genreRepository.Create(genre);
        }

        public Genre Get(int id)
        {
            var genre = _genreRepository.Get(id);

            return genre;
        }

        public IEnumerable<Genre> Get()
        {
            var genres = _genreRepository.Get();

            return genres;
        }

        public void Remove(int id)
        {
            var genre = _genreRepository.Get(id);
            if(genre == null)
            {
                throw new InvalidOperationException("Wrong id");
            }

            _genreRepository.Delete(genre.GenreId);
        }

        public void Update(Genre genre)
        {
            _genreRepository.Edit(genre);
        }
    }
}
