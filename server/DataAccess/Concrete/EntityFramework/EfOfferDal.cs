using Entities.Concrete;
using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOfferDal : EfEntityRepositoryBase<Offer, ProductCatalogContext>, IOfferDal
    {
        public List<OfferDetailsDto> GetOfferDetails(Expression<Func<OfferDetailsDto, bool>> filter = null)
        {
            using (ProductCatalogContext contex = new ProductCatalogContext())
            {
                var result = from o in contex.Offers
                             join p in contex.Products on o.ProductId equals p.ProductId
                             join u in contex.Users on o.UserId equals u.UserId
                             select new OfferDetailsDto
                             {
                                 OfferId = o.OfferId,
                                 OfferTime=o.OfferTime,
                                 ProductId=p.ProductId,
                                 UserId=u.UserId,
                                 ProductName=p.ProductName,
                                 UserName=u.FirstName+" "+u.LastName,
                                 OfferedPrice = o.OfferedPrice,
                                 IsAccepted = o.IsAccepted ,
                                 IsSold=p.IsSold
                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public void UpdateIsAccepted(int offerId, bool isAccepted)
        {
            var offer = new Offer { OfferId = offerId, IsAccepted = isAccepted };
            using (ProductCatalogContext contex = new ProductCatalogContext())
            {
                contex.Offers.Attach(offer);
                contex.Entry(offer).Property(o => o.IsAccepted).IsModified = true;
                contex.SaveChanges();
            }
        }
    }
}
