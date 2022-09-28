using Core.Entities;

namespace Entities.DTOs
{
    public class ProductDetailsDto:IDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string UserName { get; set; }
        public string? BrandName { get; set; }
        public string? ColorName { get; set; }
        public string UsingStatusName { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public int Price { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public DateTime InsertTime { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

    }
}
