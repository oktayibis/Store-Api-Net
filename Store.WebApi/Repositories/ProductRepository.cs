using System;
using System.Collections.Generic;
using System.Linq;
using Store.WebApi.Entities;
using Store.WebApi.Interfaces;

namespace Store.WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        // create a list of products
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = Guid.NewGuid(), Name = "Tomato Soup" , Price = 19.99, IsPublished = true, Description = "Lorem 1"},
            new Product { Id = Guid.NewGuid(), Name = "Yo-yo", Price = 3.75 , IsPublished = true, Description = "Lorem 2", IsDiscounted = true, DiscountPercentage = 10.00},
            new Product { Id = Guid.NewGuid(), Name = "Hammer",  Price = 16.99, IsPublished = true, Description = "Lorem 3"}
        };


        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> AddProduct(Product product)
        {
            _products.Add(product);
            return _products;
        }

        public Product UpdateProduct(Product product)
        {
            // update the product
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.IsPublished = product.IsPublished;
                existingProduct.IsDiscounted = product.IsDiscounted;
                existingProduct.DiscountPercentage = product.DiscountPercentage;
             
            }

            return existingProduct;
        }

        public Product DeleteProduct(Guid id)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
            }

            return existingProduct;
        }

        public IEnumerable<Product> SearchProduct(string search)
        {
            return _products.Where(p => p.Name.ToLower().Contains(search.ToLower()));
        }
        
        // Get product by Slug
        public Product GetProductBySlug(string slug)
        {
            return _products.FirstOrDefault(p => p.Slug == slug);
        }
        
        // Add stock to product
        public Product UpdateStock(Guid id, IStock stock)
        {
            var existingProduct = GetProduct(id);
            
            if (existingProduct.Stocks is null)
            {
                existingProduct.Stocks = new List<IStock>();
            }
            var existingStock = existingProduct.Stocks.FirstOrDefault(s => s.Size == stock.Size && s.ColorId == stock.ColorId);
            if (existingStock != null)
            {
                existingStock.Quantity += stock.Quantity;
            }
            else
            {
                existingProduct.Stocks.Add(stock);
            }
         


            return existingProduct;
        }

        public Product RemoveStock(Guid productId, Guid stockId)
        {
            var existingProduct = GetProduct(productId);
            var existingStock = existingProduct.Stocks.FirstOrDefault(s => s.Id == stockId);
            if (existingStock != null)
            {
                existingProduct.Stocks.Remove(existingStock);
            }

            return existingProduct;
        }
        
    }
}