using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (CarContext context = new CarContext())
            {
                //addedEntity reach the entity reference numbers from coming the add function.
                var addedEntity = context.Entry(entity);
                //then we are adding this reference type
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (CarContext context = new CarContext())
            {
                //DeletedEntity reach the entity reference numbers from coming the add function.
                var deletedEntity = context.Entry(entity);
                //then we deleted this reference type
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {

            using (CarContext context = new CarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                //we are taking all cars data
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();

            }
        }

        public void Update(Brand entity)
        {
            using (CarContext context = new CarContext())
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
