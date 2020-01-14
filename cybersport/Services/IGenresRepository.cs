using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using cybersport.Models;
using Microsoft.EntityFrameworkCore;

namespace cybersport.Services
{
    public interface IGenresRepository
    {
        void Add(Genre genre);
        Task Save();
        Task<List<Genre>> GetAll();
        Task<Genre> editGenre(int? id);
        Task<List<Genre>> GetGenres(Expression<Func<Genre, bool>> predicate);
    }
}
