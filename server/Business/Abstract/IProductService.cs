using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        IDataResult<List<ProductDetailsDto>> GetAllProductDetails();
        IDataResult<List<ProductDetailsDto>> GetProductDetailById(int productId);
        IDataResult<List<Product>> GetProductsByUserId(int id);
        IDataResult<List<ProductDetailsDto>> GetProductDetailsByCategory(int categoryId);
        IResult UpdateIsSold(int productId,bool isSold);
    }
}
