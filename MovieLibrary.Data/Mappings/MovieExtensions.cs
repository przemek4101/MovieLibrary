using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Mappings
{
    public static class MovieExtensions
    {
        public static MovieDto AsMovieDto(this Movie from)
        {
            var movieDto = new MovieDto
            {
                Id = from.Id,
                Description = from.Description,
                ImdbRating = from.ImdbRating,
                Title = from.Title,
                Year = from.Year,
                Categories = from.MovieCategories.Select(x=> new CategoryDto(x)).ToList()
            };
            return movieDto;
        }

        public static Movie AsMovie(this MovieDto from)
        {
            var movie = new Movie
            {
                Id = from.Id,
                Title = from.Title,
                Description = from.Description,
                Year = from.Year,
                ImdbRating = from.ImdbRating,
            };
            return movie;
        }
    }
}
