using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Api.Services
{
    public interface IMovieManagementService
    {
        Task CreateAsync(MovieDto movieDto);
        Task<MovieDto> ReadByIdAsync(int id);
        Task UpdateAsync(MovieDto movieDto);
        Task DeleteAsync(int id);
    }
}
