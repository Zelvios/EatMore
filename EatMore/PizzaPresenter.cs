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
        
        private string _Beskrivelse;

        public string Beskrivelse
        {
            get { return _Beskrivelse; }
            set
            {
                _Beskrivelse = value;
                OnPropertyChanged("Beskrivelse");

            }
        }
        public ObservableCollection<Top> ToppingOver { get; set; } = new ObservableCollection<Top>();
        public int customID { get; set; }
        public double BasePris { get; set; }

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

        public PizzaPresenter(int ID, int Nummer, string Navn, ObservableCollection<Top> ToppingOver, double Pris, int Antal, string Beskrivelse)
        {
            this.ID = ID;
            this.Nummer = Nummer;
            this.Navn = Navn;
            this.ToppingOver = ToppingOver;
            this.Pris = Pris;
            this.Antal = Antal;
            this.Beskrivelse = Beskrivelse;
        }

        public PizzaPresenter(int ID, int Nummer, string Navn, ObservableCollection<Top> ToppingOver, double Pris, int Antal, int customID, double BasePris)
        {
            this.ID = ID;
            this.Nummer = Nummer;
            this.Navn = Navn;
            this.ToppingOver = ToppingOver;
            this.Pris = Pris;
            this.Antal = Antal;
            this.customID = customID;
            this.BasePris = BasePris;
        }
        int counter = 0;
        public PizzaPresenter(Pizza p)
        {
            this.ID = p.ID;
            StringBuilder sb = new StringBuilder("");



            foreach (var topping in p.Top)
            {

                sb.Append(topping.Navn);
                ToppingOver.Add(new Top(topping.ID, topping.Navn, topping.pris));
                counter++;
                if (p.Top.Count != counter)
                {
                    if (counter == p.Top.Count - 1)
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
