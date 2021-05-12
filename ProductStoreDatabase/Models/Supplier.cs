using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Logos = new HashSet<Logo>();

        }
        public int SupplierId { get; set; }
        public string Company { get; set; }
        public int ProductTypeId { get; set; }
      //  public string LogoFileName { get; set; }

        public ICollection<Product> Products { get; set; }

        public virtual ICollection<Logo> Logos { get; set; }
    }
}