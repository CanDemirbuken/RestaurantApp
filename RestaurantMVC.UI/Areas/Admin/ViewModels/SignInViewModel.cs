using System.ComponentModel.DataAnnotations;

namespace RestaurantMVC.UI.Areas.Admin.ViewModels
{
    public class SignInViewModel
    {
        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email boş bırakılamaz.")]
        [Display(Name = "Email :")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; }
    }
}
