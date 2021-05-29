using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.ViewModels
{
    public class CreateSupplierViewModel
    {
        public CreateSupplierViewModel()
        {
            ProductTypes = new List<SelectListItem>();
        }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Enter Company Name..")]
        public string Company { get; set; }


        public IEnumerable<SelectListItem> ProductTypes { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Please Select Company..")]
        public int SelectedTypeId { get; set; }

        public bool ErrorMessageVisible { get; set; }


        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public string CreatedOn { get; set; }
        public string EditedOn { get; set; }
        public int SupplierChangeId { get; set; }
    }
}
