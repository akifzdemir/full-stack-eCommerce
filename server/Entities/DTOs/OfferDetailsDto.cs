using Core.Entities;

namespace Entities.DTOs
{
    public class OfferDetailsDto:IDto
    {
        public int OfferId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int OfferedPrice { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsSold { get; set; }
        public DateTime? OfferTime { get; set; }

    }
}
