using System.ComponentModel.DataAnnotations;
using System.Runtime;

using COMP_.Entities.Enum;
using COMP_.Validation;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonConverter = Newtonsoft.Json.JsonConverter;





namespace COMP_.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
      
        public string Name { get; set; }
        public string? Photo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Zip is Required")]
        [RegularExpression(@"^[0-9]{5}-[0-9]{3}", ErrorMessage = "Invalid Zip Code format")]
        public string CEP { get; set; }
        [Required]
        [JsonProperty("error")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Profile Profile { get; set; }
        [Required]
        [StringLength(11)]
        [ContainsSymbols]
        public string CPF { get; set; }






    }
}
