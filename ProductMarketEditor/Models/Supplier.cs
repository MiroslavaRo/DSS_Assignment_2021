using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

#nullable disable

namespace ProductMarketEditor.Models
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
            ProductChanges = new HashSet<ProductChange>();
        }

        public int SupplierId { get; set; }
        public string Company { get; set; }
        public int? ProductTypeId { get; set; }
     //   public string LogoFileName { get; set; }
     //   public IFormFile LogoFile { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductChange> ProductChanges { get; set; }
    }
}
