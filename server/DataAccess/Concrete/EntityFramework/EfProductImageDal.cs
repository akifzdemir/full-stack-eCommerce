using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductImageDal:EfEntityRepositoryBase<ProductImage,ProductCatalogContext>,IProductImageDal
    {
    }
}
