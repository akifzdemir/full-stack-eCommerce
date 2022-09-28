using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using DataAccess.Abstract;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules;
using Entities.DTOs;
using Business.BusinessAspect.Autofac;
using Core.Utilities.Logger;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILoggerService _loggerService;
       
        public ProductManager(IProductDal productDal,ILoggerService loggerService)
        {
            _productDal = productDal;
            _loggerService = loggerService;
        }
        [ValidationAspect(typeof(ProductValidator))]
        [AuthOperation("user")]
        public IResult Add(Product entity)
        {
            entity.InsertTime = DateTime.Now;
            entity.IsSold = false;
            _productDal.Add(entity);
            return new SuccessResult(entity.ProductId.ToString());
        }

        public IResult Delete(Product entity)
        {
            
            _productDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            _loggerService.LogInfo("GET ProductList");
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<List<ProductDetailsDto>> GetAllProductDetails()
        {
            _loggerService.LogInfo("GET ProductDetails");
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetails());
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==id));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetailById(int productId)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetails(p=>p.ProductId==productId));
        }

        public IDataResult<List<ProductDetailsDto>> GetProductDetailsByCategory(int categoryId)
        {
            return new SuccessDataResult<List<ProductDetailsDto>>(_productDal.GetAllProductDetails(p=>p.CategoryId==categoryId));
        }

        public IDataResult<List<Product>> GetProductsByUserId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UserId==id));
        }

        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new SuccessResult();
        }

        [AuthOperation("user")]
        public IResult UpdateIsSold(int productId, bool isSold)
        {
            _productDal.UpdateIsSold(productId, isSold);
            return new SuccessResult();
        }
    }
}
