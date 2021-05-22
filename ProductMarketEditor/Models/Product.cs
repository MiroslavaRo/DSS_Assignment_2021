using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace ProductMarketEditor.Models
{
    public class Product
    {
        /*
        public Product()
        {
            ProductPhotos = new HashSet<ProductPhoto>();
            ProductChanges = new HashSet<ProductChange>();
        }*/
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }

           public string ImageFileName { get; set; }

        // [NotMapped]
        //  public IFormFile ImageFile { get; set; }


        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
        public virtual ICollection<ProductChange> ProductChanges { get; set; }
    }
}
