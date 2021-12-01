using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Api.Services;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;

using AutoMapper;
using System.Text.Json;

namespace MovieLibrary.Api.Controllers
{

    [Route("/v1/Movie/Filter")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            var output = await _filterService.GetAllAsync();
            return Ok(output);
        }

        [HttpGet("GetByTitle")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetByTitle([FromQuery] string title)
        {
            var output = await _filterService.GetByTitleAsync(title);
            return Ok(output);
        }

        [HttpGet("GetByIMDB")]
        public ActionResult<IEnumerable<Movie>> GetByIMDB([FromQuery] decimal minImdb, decimal maxImdb)
        {
            var output = _filterService.GetByIMDBNoteAsync(minImdb, maxImdb);
            return Ok(output);
        }

        [HttpGet("GetByCategoryId")]
        public async Task<ActionResult<IEnumerable<MovieCategory>>> GetByCategoryIdAsync([FromQuery] int[] categoryId)
        {
            var output = await _filterService.GetByCategoryIdAsync(categoryId);
            return Ok(output);
        }

        [HttpGet("SortByIMDB")]
        public async Task<ActionResult<IEnumerable<Movie>>> SortByImdbAsync()
        {
            var output = await _filterService.SortByImdbAsync();
            return Ok(output);
        }
    }
}
