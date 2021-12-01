using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieLibrary.Core.Repositories;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Mappings;

namespace MovieLibrary.Api.Services
{
    public class CategoryManagementService : ICategoryManagementService
    {
        private readonly ICategoryManagementRepository _categoryManagementRepository;

        public CategoryManagementService(ICategoryManagementRepository categoryManagementRepository)
        {
            _categoryManagementRepository = categoryManagementRepository;
        }
        public async Task Create(CategoryDto categoryDto)
        {
            var category = categoryDto.AsCategory();
            await _categoryManagementRepository.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryManagementRepository.DeleteAsync(id);
        }

        public async Task<CategoryDto> ReadByIdAsync(int id)
        {
            var category = await _categoryManagementRepository.ReadByIdAsync(id);
            return category.AsCategoryDto();
        }

        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            var category = categoryDto.AsCategory();
            await _categoryManagementRepository.UpdateAsync(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await _categoryManagementRepository.GetAllAsync();
        }
    }
}
