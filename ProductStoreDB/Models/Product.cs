using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDB.Models
{
   public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        /* 
         public string PhotoFileName{get;set;}
        */
    }
}
