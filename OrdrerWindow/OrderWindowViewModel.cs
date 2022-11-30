using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatMore;

namespace OrdrerWindow
{
    public class OrderWindowViewModel : INotifyPropertyChanged
    {
        
        private ObservableCollection<JoeIsHungry> _OrderListe;
        int NummerID = 1;

        public ObservableCollection<JoeIsHungry> OrderListe
        {
            get { return _OrderListe; }
            set
            {
                _OrderListe = value;
                OnPropertyChanged("OrderListe");
            }
        }

        public OrderWindowViewModel() 
        {
            _OrderListe = new ObservableCollection<JoeIsHungry>();
        }

        public void addordere(ObservableCollection<OrderTing> filJson)
        {
            OrderListe.Add(new JoeIsHungry(NummerID, new ObservableCollection<OrderTing>(filJson)));
            NummerID++;
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
