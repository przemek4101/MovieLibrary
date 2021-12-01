using System;
using System.Collections.Generic;
using System.Text;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Mappings
{
    public static class CategoryExtensions
    {
        public static CategoryDto AsCategoryDto(this Category from)
        {
            var categoryDto = new CategoryDto
            {
                Id = from.Id,
                Name = from.Name,
            };
            return categoryDto;
        }

        public static Category AsCategory(this CategoryDto from)
        {
            var category = new Category
            {
                Id = from.Id,
                Name = from.Name,
            };
            return category;
        }
    }
}
