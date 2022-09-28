using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailsDto> GetAllProductDetails(Expression<Func<ProductDetailsDto, bool>> filter = null);
        void UpdateIsSold(int productId,bool isSold);
    }
}
