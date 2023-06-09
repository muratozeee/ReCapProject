using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByEmail(string? email);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

    }
}
