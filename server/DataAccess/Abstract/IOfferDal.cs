using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IOfferDal:IEntityRepository<Offer>
    {
        List<OfferDetailsDto> GetOfferDetails(Expression<Func<OfferDetailsDto, bool>> filter = null);
        void UpdateIsAccepted(int offerId, bool isAccepted);
    }
}
