using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimApi.Data;
using SimApi.Data.Repository;
using SimApi.Schema;
using System.Collections.Generic;

namespace SimApi.Service.Controllers
{
    [Route("simapi/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository repository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<CategoryResponse> GetAll()
        {
            var list = repository.GetAll();
            var mapped = mapper.Map<List<CategoryResponse>>(list);
            return mapped;
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryResponse> GetById(int id)
        {
            var row = repository.GetById(id);
            if (row == null)
            {
                return NotFound($"Category with Id {id} not found.");
            }

            var mapped = mapper.Map<CategoryResponse>(row);
            return mapped;
        }

        [HttpGet("Count")]
        public int Count()
        {
            var count = repository.GetAllCount();
            return count;
        }

        [HttpPost]
        public CategoryResponse Post([FromBody] CategoryRequest request)
        {
            var entity = mapper.Map<Category>(request);
            repository.Insert(entity);
            repository.Complete();

            var mapped = mapper.Map<CategoryResponse>(entity);
            return mapped;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryRequest request)
        {
            request.Id = id;
            var entity = mapper.Map<Category>(request);
            repository.Update(entity);
            repository.Complete();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteById(id);
            repository.Complete();
        }

        [HttpGet("{categoryId}/Products")]
        public List<ProductResponse> GetProductsByCategoryId(int categoryId)
        {
            var category = repository.GetById(categoryId);
            var products = category.Products;
            var mapped = mapper.Map<List<ProductResponse>>(products);
            return mapped;
        }
    }
}
