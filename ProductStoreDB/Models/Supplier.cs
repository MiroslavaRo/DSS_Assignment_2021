using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
   public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierNumber { get; set; }
        public string SupplierName { get; set; }
        public int? ProductTypeId { get; set; } 
        public string LogoFileName{get;set;}
         
        public ICollection<Product> Products { get; set; }


    }
}
