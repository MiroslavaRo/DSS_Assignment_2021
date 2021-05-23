﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ProductMarketEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.ViewModels
{
    public class ProductListEditViewModel
    {

        public Product ProductToBeEdited { get; set; }
        public List<SelectListItem> Suppliers { get; set; }

        public bool SuccessMessageVisible { get; set; }
        public bool ErrorMessageVisible { get; set; }

    }
}
