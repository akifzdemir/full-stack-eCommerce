using Core.Entities;

namespace Entities.Concrete
{
    public class ProductImage:IEntity
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
