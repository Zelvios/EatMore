using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Dynamic;

namespace EatMore
{
    public class Pizza : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public int Nummer { get; private set; }
        public string Navn { get; private set; }
        public ObservableCollection<Top> Top { get; private set; }
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
        public int Antal {
            get { return _Antal; }
            set
            {
                if (value < 0 || value > 11) { value = 0; }
                _Antal = value;
                OnPropertyChanged("Antal");
            }
        }




        /// <summary>
        /// hvad den gør
        /// </summary>
        /// <param name="ID"> pizzaens ID - </param>
        /// <param name="Nummer">  </param>
        /// <param name="Navn"></param>
        /// <param name="toppings"></param>
        /// <param name="Pris"></param>
        public Pizza (int ID, int Nummer, string Navn, ObservableCollection<Top> toppings, double Pris, int Antal)
        {
            this.ID = ID;
            this.Nummer = Nummer;
            this.Navn = Navn;
            this.Top = toppings;
            this.Pris = Pris;
            this.Antal = Antal;
        }

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
