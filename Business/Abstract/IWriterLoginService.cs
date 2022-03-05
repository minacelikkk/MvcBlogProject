using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWriterLoginService
    {
        Writer GetWriter(string userName,string password);
    }
}
