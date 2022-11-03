using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EatMore
{
    public class MainWindowViewModel
    {
        DAL dal;

        public ObservableCollection<PizzaPresenter> Pizza { get; set; } = new ObservableCollection<PizzaPresenter>();
        public ObservableCollection<Pizza> OrderListe { get; set; }

        public ObservableCollection<Pizza> _LocalPizza { get; private set; }

        public ObservableCollection<Drik> _LocalDrik { get; private set; }
        public ObservableCollection<DrikHalv> _LocalDrikHalv { get; private set; }
        public ObservableCollection<DrikAndet> _LocalDrikAndet { get; private set; }


        public MainWindowViewModel()
        {
            dal = new DAL();
            _LocalPizza = dal.Pizza_Get();
            _LocalDrik = dal.Drik_Get();
            _LocalDrikHalv = dal.DrikHalv_Get();
            _LocalDrikAndet = dal.DrikAndet_Get();
            foreach (var p in dal.Get())
            {
                Pizza.Add(new PizzaPresenter(p));
            }
        }
    }
}
