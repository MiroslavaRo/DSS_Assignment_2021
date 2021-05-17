using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStoreEditor.ViewModels
{
    public class CreateProductViewModel
    {
        public CreateProductViewModel()
        {
            Suppliers = new List<SelectListItem>();
        }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please Enter Product Name..")]
        public string ProductName { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Please Select Company..")]
        public int SelectedSupplierId { get; set; }

        
        
        /*
        [Display(Name ="Upload Photo")]
        [Required(ErrorMessage = "Please Upload Photo..")]
        public IFormFile ImageFile { get; set; }
        */


    }
}
