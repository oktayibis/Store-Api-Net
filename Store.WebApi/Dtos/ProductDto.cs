using System;
using System.Collections.Generic;

namespace Store.WebApi.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public List<string> Categories { get; set; }
        public string Slug { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsDiscounted { get; set; }
        public double DiscountPercentage { get; set; }
        public double NetPrice { get; set; }
        public Guid Id { get; set; }
    }
}