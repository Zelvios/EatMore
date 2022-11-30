using EatMore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdrerWindow
{
     public class OrderTing
    {
        public int ID { get; set; }
        public int Nummer { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public ObservableCollection<Top> ToppingOver { get; set; }
        private double _Pris;

        public double Pris
        {
            get { return _Pris; }
            set
            {
                _Pris = value;
                
            }
        }
        private int _Antal;
        public int Antal
        {
            get { return _Antal; }
            set
            {

                _Antal = value;
                
            }
        }

        public OrderTing(int ID, int Nummer, string Navn, ObservableCollection<Top> ToppingOver, double Pris, int Antal, string Beskrivelse)
        {
            this.ID = ID;
            this.Nummer = Nummer;
            this.Navn = Navn;
            this.ToppingOver = ToppingOver;
            this.Pris = Pris;
            this.Antal = Antal;
            this.Beskrivelse = Beskrivelse;
        }
    }
}
