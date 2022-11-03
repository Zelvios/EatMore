using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class DinTop
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public double pris { get; set; }


        public DinTop(int ID, string Navn, double Pris)
        {
            this.ID = ID;
            this.Navn = Navn;
            this.pris = Pris;
        }
    }
}
