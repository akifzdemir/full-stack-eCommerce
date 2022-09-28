using Entities.Concrete;
using DataAccess.Abstract;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,ProductCatalogContext>,ICategoryDal
    {
    }
}
