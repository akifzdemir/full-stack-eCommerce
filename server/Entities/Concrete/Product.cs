using Core.Entities;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int? UserId { get; set; }
        public int CategoryId { get; set; }
        public int? ColorId { get; set; }
        public int UsingStatusId { get; set; }
        public int? BrandId { get; set; }
        public int Price { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public DateTime InsertTime { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
     
    }
}
