using System.ComponentModel.DataAnnotations;

namespace BlazorAppCodingDroplets.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required"),MaxLength(10,ErrorMessage = "Max Length should be 10.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required"), EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
