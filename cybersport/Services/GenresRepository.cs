using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using cybersport.Data;
using cybersport.Models;
using Microsoft.EntityFrameworkCore;

namespace cybersport.Services
{
    public class GenresRepository : IGenresRepository
    {
        readonly DatabaseContext _context;
        
        public GenresRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void Add(Genre genre)
        {
            _context.Add(genre);
        }

        public Task<Genre> editGenre(int? id)
        {
            return _context.Genres.FindAsync(id);
        }

        public Task<List<Genre>> GetAll()
        {
            return _context.Genres.ToListAsync();
        }
        

        public Task<List<Genre>> GetGenres(Expression<Func<Genre, bool>> predicate)
        {
            return _context.Genres.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
