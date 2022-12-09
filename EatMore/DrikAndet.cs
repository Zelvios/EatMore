using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class DrikAndet : INotifyPropertyChanged
    {
        public int ID { get; private set; }
        public string L { get; private set; }
        public string Navn { get; private set; }
        
        public int Pris { get; private set; }
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

        public double BasePris { get; internal set; }

        public DrikAndet(int ID, string L, string Navn, int Pris, int Antal, double BasePris)
        {
            this.ID = ID;
            this.L = L;
            this.Navn = Navn;
            this.Pris = Pris;
            this.Antal= Antal;
            this.BasePris = BasePris;

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
