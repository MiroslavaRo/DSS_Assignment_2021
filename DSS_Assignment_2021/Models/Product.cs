using System;
using System.Collections.Generic;

#nullable disable

namespace DSS_Assignment_2021.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public string PhotoFileName { get; set; }
        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
