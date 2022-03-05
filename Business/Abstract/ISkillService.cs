using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetAll();
        void Add(Skill skill);
        void Delete(Skill skill);
        void Update(Skill skill);
        Skill GetById(int id);
    }
}
