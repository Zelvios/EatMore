using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class DrikHalv
    {
        public int ID { get; private set; }
        public double L { get; private set; }
        public string Navn { get; private set; }
        public double Pris { get; private set; }


        public DrikHalv(int ID, double L, string Navn, double Pris)
        {
            this.ID = ID;
            this.L = L;
            this.Navn = Navn;
            this.Pris = Pris;

        }
    }
}
