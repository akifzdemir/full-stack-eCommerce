using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ProductCatalogContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {

            using (var context = new ProductCatalogContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }

        public void UpdateAccessFailedCount(int userId,int accessFailedCount)
        {
            var user = new User { UserId = userId, AccessFailedCount = accessFailedCount+1 };
            using (ProductCatalogContext contex = new ProductCatalogContext())
            {
                contex.Users.Attach(user);
                contex.Entry(user).Property(u => u.AccessFailedCount).IsModified = true;
                contex.SaveChanges();
            }
        }

        public void UpdateUserStatus(int userId, bool status)
        {
            var user = new User { UserId = userId, Status = status };
            using (ProductCatalogContext contex = new ProductCatalogContext())
            {
                contex.Users.Attach(user);
                contex.Entry(user).Property(u => u.Status).IsModified = true;
                contex.SaveChanges();
            }
        }
    }
}
