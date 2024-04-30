using System.ComponentModel.DataAnnotations;
using System.Runtime;
using COMP_.Entities.Enum;

namespace COMP_.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Profile Profile { get; set; }
        [Required]
        public string CPF { get; set; }






    }
}
