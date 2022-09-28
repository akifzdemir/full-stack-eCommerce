using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using DataAccess.Abstract;
using Business.BusinessAspect.Autofac;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OfferManager : IOfferService
    {
        IOfferDal _offerDal;
        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
        }
        [AuthOperation("user")]
        public IResult Add(Offer entity)
        {
            entity.OfferTime = DateTime.Now;
            _offerDal.Add(entity);
            return new SuccessResult();
        }
        [AuthOperation("user")]
        public IResult Delete(Offer entity)
        {
            _offerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Offer>> GetAll()
        {
            return new SuccessDataResult<List<Offer>>(_offerDal.GetAll());
        }

        public IDataResult<Offer> GetById(int id)
        {
            return new SuccessDataResult<Offer>(_offerDal.Get(o=>o.OfferId==id));
        }

        public IDataResult<List<OfferDetailsDto>> GetOfferDetailsByProductId(int productId)
        {
            return new SuccessDataResult<List<OfferDetailsDto>>(_offerDal.GetOfferDetails(o=>o.ProductId==productId));
        }

        public IDataResult<List<OfferDetailsDto>> GetOfferDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<OfferDetailsDto>>(_offerDal.GetOfferDetails(o => o.UserId == userId));
        }
        [AuthOperation("user")]
        public IResult Update(Offer entity)
        {
            _offerDal.Update(entity);
            return new SuccessResult();
        }

        public IResult UpdateIsAccepted(int offerId, bool isAccepted)
        {
            _offerDal.UpdateIsAccepted(offerId, isAccepted);
            return new SuccessResult();
        }
    }
}
