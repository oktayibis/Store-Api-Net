using System;

namespace Store.WebApi.Interfaces
{
    public class IStock
    {
        public string Size { get; set; }
        public int Quantity { get; set; }
        public Guid ColorId { get; set; }
        public Guid Id { get; set; }
    }
}