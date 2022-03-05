using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [StringLength(30)]
        public string SkillName { get; set; }
        public int SkillLevel { get; set; }
    }
}
 