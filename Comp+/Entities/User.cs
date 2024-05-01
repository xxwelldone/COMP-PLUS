using System.ComponentModel.DataAnnotations;
using System.Runtime;
using COMP_.Entities.Enum;
using COMP_.Validation;

namespace COMP_.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ContainsSymbols]
        public string Name { get; set; }
        public string Photo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public Profile Profile { get; set; }
        [Required]
        [StringLength(11)]
        [ContainsSymbols]
        public string CPF { get; set; }






    }
}
