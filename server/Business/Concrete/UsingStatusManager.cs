using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UsingStatusManager : IUsingStatusService
    {
        IUsingStatusDal _usingStatusDal;
        public UsingStatusManager(IUsingStatusDal usingStatusDal)
        {
            _usingStatusDal = usingStatusDal;
        }

        public IResult Add(UsingStatus entity)
        {
            _usingStatusDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(UsingStatus entity)
        {
            _usingStatusDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<UsingStatus>> GetAll()
        {
            return new SuccessDataResult<List<UsingStatus>>(_usingStatusDal.GetAll());
        }

        public IDataResult<UsingStatus> GetById(int id)
        {
            return new SuccessDataResult<UsingStatus>(_usingStatusDal.Get(u=>u.UsingStatusId==id));
        }

        public IResult Update(UsingStatus entity)
        {
            _usingStatusDal.Update(entity);
            return new SuccessResult();
        }
    }
}
