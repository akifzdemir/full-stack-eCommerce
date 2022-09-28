using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [AuthOperation("user")]
        public IResult Add(Category entity)
        {
            _categoryDal.Add(entity);
            return new SuccessResult();
        }
        [AuthOperation("user")]
        public IResult Delete(Category entity)
        {
            _categoryDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId==id));
        }
        [AuthOperation("user")]
        public IResult Update(Category entity)
        {
            _categoryDal.Update(entity);
            return new SuccessResult();
        }
    }
}
