using System;
using System.Collections.Generic;
using System.Text;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Mappings
{
    public static class MovieCategoryExtensions
    {
        public static CategoryDto AsCategoryDto(this MovieCategory from)
        {
            var categoryDto = new CategoryDto
            {
                Id = from.Category.Id,
                Name = from.Category.Name,
            };
            return categoryDto;
        }
    }   
}
