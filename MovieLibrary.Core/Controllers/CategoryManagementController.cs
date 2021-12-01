using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Api.Services;
using MovieLibrary.Data.Dto;
using Newtonsoft.Json;

namespace MovieLibrary.Api.Controllers
{
    [Route("/v1/MovieCategory")]
    [ApiController]
    public class CategoryManagement : ControllerBase
    {
        private readonly ICategoryManagementService _categoryManagementService;
        private readonly IFilterService _filterService;

        public CategoryManagement(ICategoryManagementService categoryManagementService, IFilterService filterService)
        {
            _categoryManagementService = categoryManagementService;
            _filterService = filterService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            var list = await _categoryManagementService.GetAllAsync();
            if(ModelState.IsValid)
            {
                if(!list.Any(x => x.Name == categoryDto.Name))
                {
                    await _categoryManagementService.Create(categoryDto);
                    return Ok("Category added successfully");
                }
            }
            return null;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get( int id)
        {
            var categoryDto = await _categoryManagementService.ReadByIdAsync(id);
            return Ok(JsonConvert.SerializeObject(categoryDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _categoryManagementService.DeleteAsync(id);
            return Ok("Category deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] CategoryDto editCategory)
        {
            var categoryDto = await _categoryManagementService.ReadByIdAsync(editCategory.Id);
            if (!ModelState.IsValid || categoryDto == null)
            {
                return BadRequest("Something went wrong");
            }
            await _categoryManagementService.UpdateAsync(editCategory);
            return Ok("Category updated succesfully");
        }
    }
}
