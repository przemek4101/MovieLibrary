using System;
using System.Collections.Generic;
using System.Text;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Dto
{
    public class CategoryDto
    {
        public CategoryDto()
        {

        }

        public CategoryDto(MovieCategory movieCategory)
        {
            Id = movieCategory.Category.Id;
            Name = movieCategory.Category.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
