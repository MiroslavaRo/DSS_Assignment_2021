using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace ProductMarketEditor.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ImageFileName { get; set; }
        public IFormFile ImageFile { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
