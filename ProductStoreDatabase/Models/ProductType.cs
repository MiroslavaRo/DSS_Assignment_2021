using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
    public class ProductType
    {
        public ProductType()
        {
            Suppliers = new HashSet<Supplier>();
        }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }

        public ICollection<Supplier> Suppliers { get; set; }
    }
    
}