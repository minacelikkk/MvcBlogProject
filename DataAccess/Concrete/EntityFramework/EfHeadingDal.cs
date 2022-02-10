using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class EfHeadingDal:GenericRepository<Heading>,IHeadingDal
    {
    }
}
