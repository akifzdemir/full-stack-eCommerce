using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        void UpdateAccessFailedCount(int userId, int accessFailedCount);
        void UpdateUserStatus(int userId, bool status);
    }
}
