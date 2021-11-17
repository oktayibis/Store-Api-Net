using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Store.WebApi.Dtos;
using Store.WebApi.Entities;
using Store.WebApi.Interfaces;

namespace Store.WebApi.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
      private readonly IProductRepository _productRepository;
      
      public ProductController(IProductRepository productRepository)
      {
        _productRepository = productRepository;
      }
      
      [HttpGet]
      public IEnumerable<ProductDto> Get()
      {
        return _productRepository.GetProducts().Select(product => product.AsDto());
      }
      
      [HttpGet("{id}")]
      public ActionResult<ProductDto> Get(Guid id)
      {
        var item = _productRepository.GetProduct(id);
        if (item is null)
        {
          return NotFound();
        }

        return item.AsDto();
      }
      
      [HttpPost]
      public ActionResult<List<Product>> Post([FromBody] Product product)
      {
        _productRepository.AddProduct(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product.AsDto());
      }
      
      // get products by slug
      [HttpGet("slug/{slug}")]
      public ActionResult<ProductDto> GetBySlug(string slug)
      {
        var item = _productRepository.GetProductBySlug(slug);
        if (item is null)
        {
          return NotFound();
        }

        return item.AsDto();
      }

    }
}