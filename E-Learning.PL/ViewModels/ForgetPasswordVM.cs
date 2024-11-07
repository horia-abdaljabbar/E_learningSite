using System.ComponentModel.DataAnnotations;

namespace E_Learning.PL.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
