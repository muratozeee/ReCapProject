using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    //generic Constaint
    //class:it can be reference type
    //IEntity:it can be IEntity or IEntity implemented class.

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        //we can select the car and what we choose the car then we can reach this car informations directly we can reach
        T Get(Expression<Func<T, bool>> filter); //this one is not null it means we need a filter to take informations with filters.


        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
