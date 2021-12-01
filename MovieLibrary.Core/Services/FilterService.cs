using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.Repositories;
using MovieLibrary.Data;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Mappings;
using Newtonsoft.Json;

namespace MovieLibrary.Api.Services
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepository;

        public FilterService(IFilterRepository filterRepository)
        {
            _filterRepository = filterRepository;           
        }
        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            return await _filterRepository.GetAllAsync();
        }

        public async Task<IEnumerable<MovieDto>> GetByCategoryIdAsync(int[] stringCategoryId)
        {
           return await _filterRepository.GetByCategoryIdAsync(stringCategoryId);           
        }

        public async Task<IEnumerable<MovieDto>> GetByIMDBNoteAsync(decimal imdbNoteMin, decimal imdbNoteMax)
        {
            return await _filterRepository.GetByIMDBNoteAsync(imdbNoteMin, imdbNoteMax);            
        }

        public async Task<IEnumerable<MovieDto>> GetByTitleAsync(string title)
        {
            return await _filterRepository.GetByTitleAsync(title);
        }
        
        public async Task<IEnumerable<MovieDto>> SortByImdbAsync()
        {
            return await _filterRepository.SortByImdbAsync();
        }  
    }
}
