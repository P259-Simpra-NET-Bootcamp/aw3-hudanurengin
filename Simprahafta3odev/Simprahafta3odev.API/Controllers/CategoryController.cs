using Simprahafta3odev.Application.Repositories.Categories;
using Simprahafta3odev.Application.ViewModels.Category;
using Simprahafta3odev.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Simprahafta3odev.Application.Repositories;
using System.Xml;

namespace Simprahafta3odev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly private ICategoryWriteRepository _categoryWriteRepository;
        readonly private ICategoryReadRepository _categoryReadRepository;

        public CategoryController(ICategoryWriteRepository categoryWriteRepository, ICategoryReadRepository categoryReadRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _categoryReadRepository = categoryReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_categoryReadRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Category category = await _categoryReadRepository.GetByIdAsync(id);
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Category model)
        {
            await _categoryWriteRepository.AddAsync(new()
            {
                CreatedBy = model.CreatedBy,
                CreatedAt = DateTime.UtcNow,
                Order= model.Order,
                Name= model.Name,

            });
            await _categoryWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Category model)
        {
            Category category = await _categoryReadRepository.GetByIdAsync(model.Id);
            category.CreatedBy = model.CreatedBy;
            category.Order = model.Order;
            category.Name = model.Name;
            category.CreatedAt = DateTime.UtcNow;
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryWriteRepository.RemoveAsync(id);
            await _categoryWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
