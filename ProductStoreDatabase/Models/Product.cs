using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace ProductStoreDatabase.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string PhotoFileName { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
