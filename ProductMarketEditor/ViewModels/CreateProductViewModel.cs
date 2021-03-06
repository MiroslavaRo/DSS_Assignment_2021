using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.ViewModels
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

        public bool ErrorMessageVisible { get; set; }


        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public string CreatedOn { get; set; }
        public string EditedOn { get; set; }
        public int ProductChangeId { get; set; }
    }
}
