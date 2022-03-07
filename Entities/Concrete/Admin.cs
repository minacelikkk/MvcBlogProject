using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(100)]
        public string AdminUserName { get; set; }
        [StringLength(100)]
        public string AdminPassword { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
        public bool AdminStatus { get; set; }
    }
    
}
