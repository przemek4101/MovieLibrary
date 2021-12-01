using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Mappings;
using Newtonsoft.Json;

namespace MovieLibrary.Core.Repositories
{
    public class FilterRepository : IFilterRepository
    {
        private readonly MovieLibraryContext _dbContext;
        public FilterRepository(MovieLibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _dbContext.Movies.Include(x => x.MovieCategories).ThenInclude(c => c.Category).ToListAsync();
            return movies.Select(x => x.AsMovieDto());
        }

        public async Task<IEnumerable<MovieDto>> GetByCategoryIdAsync(int[] categoriesId)
        {
            var movies = await GetAllAsync();
            var output = new List<MovieDto>();
            foreach(var movie in movies)
            {
                var correctMovie = FindMovieByOneElementFromListCategory(movie, categoriesId.ToList());
                if (correctMovie != null)
                {
                    output.Add(correctMovie);
                }
            }
            return output;
        }

        public async Task<IEnumerable<MovieDto>> GetByIMDBNoteAsync(decimal imdbNoteMin, decimal imdbNoteMax)
        {
            var movies = await _dbContext.Movies.Where(x => x.ImdbRating >= imdbNoteMin && x.ImdbRating <= imdbNoteMax).ToListAsync();
            return movies.Select(x => x.AsMovieDto());
        }

        public async Task<IEnumerable<MovieDto>> GetByTitleAsync(string title)
        {
            var movies = await _dbContext.Movies.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToListAsync();
            return movies.Select(x => x.AsMovieDto());
        }


        public async Task<IEnumerable<MovieDto>> SortByImdbAsync()
        {
            var movies = await _dbContext.Movies.OrderByDescending(x => ((double)x.ImdbRating)).ToListAsync();
            return movies.Select(x => x.AsMovieDto());
        }

        private static MovieDto FindMovieByOneElementFromListCategory(MovieDto movie, List<int> categoriesId)
        {
            foreach (var category in movie.Categories)
            {
                if(categoriesId.Any(x => x == category.Id))
                {
                    return movie;
                }
            }
            return null;
        }
    }
}


