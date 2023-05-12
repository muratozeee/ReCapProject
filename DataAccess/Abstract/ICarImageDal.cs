using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //CarImage is generic and it will use as a entity...
    public interface ICarImageDal : IEntityRepository <CarImage>
    {

    }
}
