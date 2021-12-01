using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Api.Exceptions;
using MovieLibrary.Data;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Mappings;

namespace MovieLibrary.Core.Repositories
{
    public class CategoryManagementRepository : ICategoryManagementRepository
    {
        private readonly MovieLibraryContext _dbContext;
        public CategoryManagementRepository(MovieLibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                throw new NotFoundException("Movie not found");
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Category> ReadByIdAsync(int id)
        {
            var category = await _dbContext.Categories.AsNoTracking().Include(x => x.MovieCategories)
               .FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                throw new Exception("Movie not found");
            }
            return category;
        }

        public async Task UpdateAsync(Category categoryUpdate)
        {
            var category =  _dbContext.Categories.Attach(categoryUpdate);
            category.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return categories.Select(x => x.AsCategoryDto());
        }
    }
}
