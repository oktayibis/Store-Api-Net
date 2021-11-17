using Store.WebApi.Dtos;
using Store.WebApi.Entities;
using Store.WebApi.utils;

namespace Store.WebApi
{
    public static class Extensions
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Categories = product.Categories,
                Description = product.Description,
                Images = product.Images,
                IsDiscounted = product.IsDiscounted,
                Slug = (product.Name+"-"+product.Description).Slugify(),
                DiscountPercentage = product.DiscountPercentage,
                IsFeatured = product.IsFeatured,
                NetPrice = product.Price - (product.Price * product.DiscountPercentage / 100),
                Stocks = product.Stocks
            };
        }
    }
}