using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.Models
{
    public class ProductPhoto
    {
        public int ProductPhotoId { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
