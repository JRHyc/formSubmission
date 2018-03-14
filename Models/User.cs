using System.ComponentModel.DataAnnotations;

namespace formSubmission.Models
{
    public abstract class BaseEntity{}

    public class User : BaseEntity
    {
        [Required]
        [MinLength(4,ErrorMessage="First name must be at least 4 letters long")]
        public string first_name {get;set;}

        [Required]
        [MinLength(3, ErrorMessage="Last name must be at least 3 letters long")]
        public string last_name {get;set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage="You must input a livable age!")]
        public int age {get;set;}

        [Required]
        [EmailAddress]
        public string email {get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string password {get;set;}
    }
}