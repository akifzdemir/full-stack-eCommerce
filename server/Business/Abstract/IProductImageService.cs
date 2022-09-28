using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IDataResult<ProductImage> GetByProductId(int id);

    }
}
