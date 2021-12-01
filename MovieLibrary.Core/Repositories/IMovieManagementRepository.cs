using System.Threading.Tasks;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Repositories
{
   public interface IMovieManagementRepository
   {
        Task CreateAsync(Movie movie);
        Task DeleteAsync(int id);
        Task<MovieDto> ReadByIdAsync(int id);
        Task UpdateAsync(Movie movieUpdate);
   }
}