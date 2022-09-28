using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Offer:IEntity
    {
        public int OfferId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int OfferedPrice { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime? OfferTime { get; set; }
    }
}
