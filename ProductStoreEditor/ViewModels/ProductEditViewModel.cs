using Microsoft.AspNetCore.Mvc.Rendering;
using ProductStoreEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStoreEditor.ViewModels
{
    public class ProductEditViewModel
    {
        public Product ProductToBeEdited { get; set; }
        public List<SelectListItem> Suppliers { get; set; }

        public bool SuccessMessageVisible { get; set; }
        public bool ErrorMessageVisible { get; set; }

    }
}
