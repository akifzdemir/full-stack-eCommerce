
using Core.Entities;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
