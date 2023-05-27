using Simprahafta3odev.Application.Repositories.Products;
using Simprahafta3odev.Application.ViewModels.Product;
using Simprahafta3odev.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Simprahafta3odev.Application.Repositories;
using System.Xml;
using Simprahafta3odev.Application.ViewModels.Category;

namespace Simprahafta3odev.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_productReadRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                CreatedBy = model.CreatedBy,
                CreatedAt = DateTime.UtcNow,
                Name = model.Name,
                Url= model.Url,
                Tag= model.Tag,
                CategoryId= model.CategoryId,

            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.CreatedBy = model.CreatedBy;
            product.Name = model.Name;
            product.CreatedAt = DateTime.UtcNow;
            product.Url = model.Url;
            product.Tag = model.Tag;   
            product.CategoryId = model.CategoryId;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
