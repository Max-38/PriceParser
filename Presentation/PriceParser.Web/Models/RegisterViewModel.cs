using System.ComponentModel.DataAnnotations;

namespace PriceParser.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public bool IsAdult { get; set; }

        public string ReturnUrl { get; set; }
    }
}
