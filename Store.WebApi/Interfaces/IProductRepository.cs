using System;
using System.Collections.Generic;
using Store.WebApi.Entities;

namespace Store.WebApi.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(Guid id);
        IEnumerable<Product> AddProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(Guid id);
        IEnumerable<Product> SearchProduct(string search);
        Product GetProductBySlug(string slug);
    }

}