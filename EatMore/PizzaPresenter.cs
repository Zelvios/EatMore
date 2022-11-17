using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class PizzaPresenter : INotifyPropertyChanged
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
                OnPropertyChanged("Pris");
            }
        }
        private int _Antal;
        public int Antal
        {
            get { return _Antal; }
            set
            {
                
                _Antal = value;
                OnPropertyChanged("Antal");
            }
        }

        public PizzaPresenter(Pizza p)
        {
            this.ID = p.ID;
            StringBuilder sb = new StringBuilder("");
            int counter = 0;
            foreach (var topping in p.Top)
            {
                counter++; 
                sb.Append(topping.Navn);
                if (p.Top.Count != counter)
                {
                    if (counter == p.Top.Count -1)
                    {
                        sb.Append(" og ");
                    }
                    else { sb.Append(", "); }
                }
                

            }

            Beskrivelse = sb.ToString();
            this.Nummer = p.Nummer;
            this.Navn = p.Navn;
            this.Pris = p.Pris;
            this.Antal = p.Antal;

            foreach (var topping in p.Top)
            {
                Pris += topping.pris;
            }
        }



        public PizzaPresenter(int ID, int Nummer, string Navn, ObservableCollection<Top> ToppingOver, double Pris, int Antal)
        {
            this.ID = ID;
            this.Nummer = Nummer;
            this.Navn = Navn;
            this.ToppingOver = ToppingOver;
            this.Pris = Pris;
            this.Antal = Antal;
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }
    }
}
