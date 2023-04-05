using Core.DataAccess.EntityFramework;
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
    //EfColorDal inherite the EfEntityRepositoryBase but using in there
    //And as a Color and CarContext and information is coming from IColorDal
    public class EfColorDal : EfEntityRepositoryBase<Color,CarContext>,IColorDal
    {
      
    }
}
