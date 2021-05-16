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

        [Display(Name = "ProductName")]
        [Required(ErrorMessage = "Please Enter Product Name..")]
        public string ProductName { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Please Select Company..")]
        public int SelectedSupplierId { get; set; }
    }
}
