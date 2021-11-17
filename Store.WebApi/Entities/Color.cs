using System;

namespace Store.WebApi.Entities
{
    public record Color
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid Id { get; set; }
    }
}