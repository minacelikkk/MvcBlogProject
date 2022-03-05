using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void Add(Skill skill)
        {
            _skillDal.Add(skill);
        }

        public void Delete(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public List<Skill> GetAll()
        {
            return _skillDal.GetAll();
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(s => s.SkillId == id);
        }

        public void Update(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
