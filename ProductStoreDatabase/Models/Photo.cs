using System;
using System.Collections.Generic;
using System.Text;

namespace ProductStoreDatabase.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string FileName { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
