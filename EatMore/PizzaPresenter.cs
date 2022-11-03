using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class PizzaPresenter
    {


        public int ID { get; set; }
        public int Nummer { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public ObservableCollection<Top> ToppingOver { get; set; }
        public double Pris { get; set; }

        public PizzaPresenter(Pizza p)
        {
            this.ID = p.ID;
            StringBuilder sb = new StringBuilder("-");
            foreach (var topping in p.Top)
            {
                sb.Append(", ");
                sb.Append(topping.Navn); 
            }

            Beskrivelse = sb.ToString();
            this.Nummer = p.Nummer;
            this.Navn = p.Navn;
            this.Pris = p.Pris;

            foreach (var topping in p.Top)
            {
                Pris += topping.pris;
            }
        }

        

        public PizzaPresenter (int ID, int Nummer, string Navn, ObservableCollection<Top> ToppingOver, double Pris)
        {
            this.ID = ID;
            this.Nummer = Nummer;
            this.Navn = Navn;
            this.ToppingOver = ToppingOver;
            this.Pris = Pris;
        }
    }
}
