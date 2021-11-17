using System;

namespace Store.WebApi.Entities
{
    public record Order
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public enum Size
        {
            xs,
            s,
            m,
            l,
            xl,
        }
        public Guid ColorId { get; set; }
        public Guid UserId { get; set; }
        public string CargoNumber { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnReason { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}