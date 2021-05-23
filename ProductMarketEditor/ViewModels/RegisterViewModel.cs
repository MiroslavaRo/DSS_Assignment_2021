using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter User Name..."), MaxLength(256)]
        public string Username { get; set; }

        [Required (ErrorMessage = "Please Enter Password..."), DataType(DataType.Password)]
       // [(ErrorMessage = "Please Enter Password...")]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        [Required(ErrorMessage = "Please Confirm Password...")]
        public string ConfirmPassword { get; set; }

        public bool ErrorMessageVisible { get; set; }


    }
}
