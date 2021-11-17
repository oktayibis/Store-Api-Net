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
      
      [HttpPut("{id}")]
      public ActionResult<ProductDto> Put(Guid id, [FromBody] Product product)
      {
        if (id != product.Id)
        {
          return BadRequest();
        }

        var updateProduct = _productRepository.UpdateProduct(product);
        return updateProduct.AsDto();
      }
      
      [HttpDelete("{id}")]
      public ActionResult<ProductDto> Delete(Guid id)
      {
        var item = _productRepository.GetProduct(id);
        if (item is null)
        {
          return NotFound();
        }

        var deletedProduct = _productRepository.DeleteProduct(item.Id);
        return deletedProduct.AsDto();
      }
      
      // Add stock to product
      [HttpPut("stock/{id}")]
      public ActionResult<ProductDto> UpdateStock(Guid id, [FromBody] IStock stock)
      {

        var updatedProduct =  _productRepository.UpdateStock(id, stock);
       
        return updatedProduct.AsDto();
      }
      
      // Remove stock from product
      [HttpDelete("stock/{productId}")]
      public ActionResult<ProductDto> RemoveStock(Guid productId, [FromBody] string stockId)
      {
        var updatedProduct = _productRepository.RemoveStock(productId, Guid.Parse(stockId));
        return updatedProduct.AsDto();
      }
      
      

    }
}