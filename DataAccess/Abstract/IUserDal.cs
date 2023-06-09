using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    //it can use the Database
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
