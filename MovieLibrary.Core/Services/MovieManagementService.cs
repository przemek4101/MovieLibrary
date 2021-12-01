using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MovieLibrary.Api.Exceptions;
using MovieLibrary.Core.Repositories;
using MovieLibrary.Data;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Mappings;

namespace MovieLibrary.Api.Services
{
    public class MovieManagementService : IMovieManagementService
    {
        private readonly IMovieManagementRepository _movieManagementRepository;

        public MovieManagementService(IMovieManagementRepository movieManagementRepository)
        {
            _movieManagementRepository = movieManagementRepository;
        }

        public async Task CreateAsync(MovieDto movieDto)
        {
            var movie = movieDto.AsMovie();
            await _movieManagementRepository.CreateAsync(movie);
        }

        public async Task DeleteAsync(int id)
        {
            await _movieManagementRepository.DeleteAsync(id);
        }

        public async Task<MovieDto> ReadByIdAsync(int id)
        {
            var movie = await _movieManagementRepository.ReadByIdAsync(id);
            return movie;
        }

        public async Task UpdateAsync(MovieDto movieDto)
        {
            var movie = movieDto.AsMovie();
            await _movieManagementRepository.UpdateAsync(movie);
        }
    }
}
