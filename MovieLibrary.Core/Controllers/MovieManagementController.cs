using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Api.Services;
using MovieLibrary.Data.Dto;
using MovieLibrary.Data.Entities;
using Newtonsoft.Json;

namespace MovieLibrary.Core.Controllers
{



    [Route("/v1/MovieManagement")]
    [ApiController]
    public class MovieManagement : ControllerBase
    {
        private readonly IMovieManagementService _movieManagementService;
        private readonly IFilterService _filterService;
        public MovieManagement(IMovieManagementService movieManagementService, IFilterService filterService)
        {
            _movieManagementService = movieManagementService;
            _filterService = filterService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] MovieDto movieDto)
        {
            var list = await _filterService.GetAllAsync();
            if (ModelState.IsValid)
            {
                if(!list.Any(x => x.Title == movieDto.Title))
                {
                    await _movieManagementService.CreateAsync(movieDto);
                    return Ok("Movie added successfully");
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get( int id)
        {
           var movieDto = await _movieManagementService.ReadByIdAsync(id);
            return Ok(JsonConvert.SerializeObject(movieDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _movieManagementService.DeleteAsync(id);
            return Ok("Movie deleted succesfully");
        }

        [HttpPut]
        public  async Task<IActionResult> Update([FromQuery] MovieDto editMovie)
        {
            var movieDto = await _movieManagementService.ReadByIdAsync(editMovie.Id);
            if (!ModelState.IsValid || movieDto == null)
            {
                return BadRequest("Something went wrong");
            }
            await _movieManagementService.UpdateAsync(editMovie);
            return Ok("Movie updated succesfully");
        }
    }
}
