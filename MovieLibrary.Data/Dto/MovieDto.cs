using System;
using System.Collections.Generic;
using System.Text;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Dto
{
    public class MovieDto
    {
        public MovieDto()
        {

        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public decimal ImdbRating { get; set; }


        public virtual ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}
