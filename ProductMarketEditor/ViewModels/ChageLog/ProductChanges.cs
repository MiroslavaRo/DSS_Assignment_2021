using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMarketEditor.ViewModels
{
    public class ProductChanges
    {
     //   public int ProductChangeLog { get; set; }
        public int ProductId { get; set; }
        public string EditedBy { get; set; }
        public string CreatedBy { get; set; }
        public DateTime EditedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
