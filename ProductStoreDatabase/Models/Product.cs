using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
    public class Product
    {
        public Product()
        {
            Photos = new HashSet<Photo>();
        }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        //public string PhotoFileName { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

    }
}