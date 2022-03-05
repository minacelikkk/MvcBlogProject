using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        void Add(Admin admin);
        void Delete(Admin admin);
        void Update(Admin admin);
        Admin GetById(int id);
    }
}
