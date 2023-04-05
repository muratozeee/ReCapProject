using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext:DbContext, new()
   
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //addedEntity reach the entity reference numbers from coming the add function.
                var addedEntity = context.Entry(entity);
                //then we are adding this reference type
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //DeletedEntity reach the entity reference numbers from coming the add function.
                var deletedEntity = context.Entry(entity);
                //then we deleted this reference type
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }



        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //we are taking all cars data
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //updatedEntity reach the entity reference numbers from coming the add function.
                var updatedEntity = context.Entry(entity);
                //then we deleted this reference type
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
