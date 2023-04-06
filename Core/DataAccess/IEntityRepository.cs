using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    //generic Constaint
    //class:it can be reference type
    //IEntity:it can be IEntity or IEntity implemented class.

    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //we can select the car and what we choose the car then we can reach this car informations directly we can reach
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);
        //this one is not null it means we need a filter to take informations with filters.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
