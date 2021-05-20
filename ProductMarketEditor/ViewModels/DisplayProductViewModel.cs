using Microsoft.AspNetCore.Mvc.Rendering;
using ProductMarketEditor.Data;
using ProductMarketEditor.Models;
using ProductMarketEditor.ViewModels.ChageLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.ViewModels
{
    public class DisplayProductViewModel
    {
        public Dictionary<Product, ProductChanges> Display { get; set; }

    }
}
