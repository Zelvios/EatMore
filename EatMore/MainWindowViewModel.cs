using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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

        public ObservableCollection<Pizza> _Order { get; set; } = new ObservableCollection<Pizza>();

        public ObservableCollection<PizzaPresenter> _OrderListe { get; set; } = new ObservableCollection<PizzaPresenter>();

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

        public void testpizzza(Pizza pizza)
        {
            _Order.Add(pizza);
            _OrderListe.Add(new PizzaPresenter(pizza));

        }



        public void AddAntal(PizzaPresenter pizza)
        {
            foreach (var p in _OrderListe)
            {
                if (p != null)
                {
                    if (p.ID == pizza.ID)
                    {
                        pizza.Antal++;
                        p.Antal = pizza.Antal;

                    }
                }
            }
        }

       
        public ObservableCollection<PizzaPresenter> OrderGet()
        {
            return _OrderListe;
        }

    }
}
