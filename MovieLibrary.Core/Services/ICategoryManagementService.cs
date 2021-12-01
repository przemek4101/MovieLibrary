using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieLibrary.Data.Dto;

namespace MovieLibrary.Api.Services
{
    public interface ICategoryManagementService
    {
        Task Create(CategoryDto categoryDto);
        Task<CategoryDto> ReadByIdAsync(int id);
        Task UpdateAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
    }
}
