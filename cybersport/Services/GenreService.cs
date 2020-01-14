using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cybersport.Models;
using Microsoft.EntityFrameworkCore;

namespace cybersport.Services
{
    public class GenreService
    {
        private readonly IGenresRepository _genresRepository;

        public GenreService(IGenresRepository genresRepository)
        {
            _genresRepository = genresRepository;
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await _genresRepository.GetAll();
        }

        public async Task <Genre> GetGenreToEdit(int? id)
        {
            return await _genresRepository.editGenre(id);
        }



        public async Task AddAndSave(Genre genre)
        {
            _genresRepository.Add(genre);
            await _genresRepository.Save();
        }
    }
}
