using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Api.Services
{
    public interface IFilterService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<IEnumerable<MovieDto>> GetByTitleAsync(string title);
        Task<IEnumerable<MovieDto>> GetByCategoryIdAsync(int[] stringCategoryId);
        Task<IEnumerable<MovieDto>> GetByIMDBNoteAsync(decimal imdbNoteMin, decimal imdbNoteMax);
        Task<IEnumerable<MovieDto>> SortByImdbAsync();
    }
}
