using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Repositories
{
    public interface ICategoryManagementRepository
    {
        Task CreateAsync(Category category);
        Task DeleteAsync(int id);
        Task<Category> ReadByIdAsync(int id);
        Task UpdateAsync(Category categoryUpdate);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
    }
}
