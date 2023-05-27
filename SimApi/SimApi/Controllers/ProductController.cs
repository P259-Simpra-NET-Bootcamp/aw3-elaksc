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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository repository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public ProductController(IProductRepository repository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<ProductResponse> GetAll()
        {
            var list = repository.GetAll();
            var mapped = mapper.Map<List<ProductResponse>>(list);
            return mapped;
        }

        [HttpGet("{id}")]
        public ProductResponse GetById(int id)
        {
            var row = repository.GetById(id);
            var mapped = mapper.Map<ProductResponse>(row);
            return mapped;
        }

        [HttpPost]
        public ProductResponse Post([FromBody] ProductRequest request)
        {
            var category = categoryRepository.GetById(request.CategoryId);

            
            var entity = mapper.Map<Product>(request);
            entity.Category = category;

            repository.Insert(entity);
            repository.Complete();

            var mapped = mapper.Map<ProductResponse>(entity);
            return mapped;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductRequest request)
        {
            var category = categoryRepository.GetById(request.CategoryId);

           

            request.Id = id;
            var entity = mapper.Map<Product>(request);
            entity.Category = category;

            repository.Update(entity);
            repository.Complete();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteById(id);
            repository.Complete();
        }
    }
}
