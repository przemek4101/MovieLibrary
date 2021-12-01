using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Api.Exceptions;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Mappings;
using MovieLibrary.Data.Dto;

namespace MovieLibrary.Core.Repositories
{
    public class MovieManagementRepository : IMovieManagementRepository
    {
        private readonly MovieLibraryContext _dbContext;
        public MovieManagementRepository(MovieLibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MovieDto> ReadByIdAsync(int id)
        {
            var movie = await _dbContext.Movies
                .Include(x=>x.MovieCategories)
                .ThenInclude(c=>c.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                throw new Exception("Movie not found");
            }
            return movie.AsMovieDto();
        }

        public async Task UpdateAsync(Movie movieUpdate)
        {
            var movie = _dbContext.Movies.Attach(movieUpdate);
            movie.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie is null)
            {
                throw new NotFoundException("Movie not found");
            }
             _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}
