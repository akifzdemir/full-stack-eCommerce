using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        void UpdateAccessFailedCount(int userId, int accessFailedCount);
        void UpdateUserStatus(int userId, bool status);

    }
}
