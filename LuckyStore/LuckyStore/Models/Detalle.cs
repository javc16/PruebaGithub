using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyStore.Models
{
    public class Detalle
    {
        public long Id { get; set; }
        public long IdFactura { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

      
       
    }
}
