using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOfferService:IGenericService<Offer>
    {
        IDataResult<List<OfferDetailsDto>> GetOfferDetailsByUserId(int userId);
        IDataResult<List<OfferDetailsDto>> GetOfferDetailsByProductId(int productId);
        IResult UpdateIsAccepted(int offerId,bool isAccepted);

    }
}
