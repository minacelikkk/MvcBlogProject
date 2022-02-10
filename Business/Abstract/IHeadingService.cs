using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        void Add(Heading heading);
        void Delete(Heading heading);
        void Update(Heading heading);
        Heading GetById(int id);
    }
}
