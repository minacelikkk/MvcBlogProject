using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();

        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(h => h.HeadingId == id);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
