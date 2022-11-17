using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class Drik : INotifyPropertyChanged
    {
        public int ID { get; private set; }
        public double L { get; private set; }
        public string Navn { get; private set; }
        public double Pris { get; private set; }
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


        public Drik(int ID, double L, string Navn, double Pris, int Antal)
        {
            this.ID = ID;
            this.L = L;
            this.Navn = Navn;
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
