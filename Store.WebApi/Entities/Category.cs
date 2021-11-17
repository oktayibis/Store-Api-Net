using System;

namespace Store.WebApi.Entities
{
    public record Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
    }
}