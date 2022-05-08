using System.ComponentModel.DataAnnotations;

namespace CarRental.Frontend.Models
{
    public class LoginModel
    {
        
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}