using System.ComponentModel.DataAnnotations;

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
        public string Password { get; set; }
        public string Location { get; set; }
        public bool IsComposting { get; set; } = false;

        public IEnumerable<User> MatchedUser;

    }
}
