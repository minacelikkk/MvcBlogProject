using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetAll();
        void Add(Contact contact);
        void Delete(Contact contact);
        void Update(Contact contact);
        Contact GetById(int id);
    }
}
