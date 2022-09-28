using Business.Abstract;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;


namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        IFileHelper _fileHelper;
        private static string ImagesPath = "wwwroot\\Images\\";

        public ProductImageManager(IProductImageDal productImageDal, IFileHelper fileHelper)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Upload(file, ImagesPath);
            productImage.Date = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(); 
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(ImagesPath + productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult();
        }

        public IDataResult<ProductImage> GetByProductId(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p=>p.ProductId==id));
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Update(file, ImagesPath + productImage.ImagePath, ImagesPath);
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }
    }
}
