using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class Order
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public int Pris { get; set; }
    }
}
