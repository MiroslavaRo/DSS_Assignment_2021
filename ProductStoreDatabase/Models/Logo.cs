using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
   public class Logo
    {
        public int LogoId { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
