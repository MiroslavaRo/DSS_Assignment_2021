using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSS_Assignment_2021.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Assignment_2021.ViewModels
{
    public class ProductEditViewModel
    {
        public Product ProductToBeEdited { get; set; }
        public List<SelectListItem> Suppliers { get; set; }
        public List<SelectListItem> ProductType { get; set; }

        public bool SuccessMessageVisible { get; set; }
        public bool ErrorMessageVisible { get; set; }

    }
}
