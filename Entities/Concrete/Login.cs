using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        [StringLength(100)]
        public string UserName { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
    }
}
