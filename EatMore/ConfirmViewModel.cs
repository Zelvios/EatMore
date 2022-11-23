using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EatMore
{
    public class ConfirmViewModel
    {
        public ObservableCollection<PizzaPresenter> Order { get; set; }
        public double TotalPris { get; set; }
        public ConfirmViewModel(ObservableCollection<PizzaPresenter> menu, double TotalPris) 
        {
            this.Order = menu;
            this.TotalPris = TotalPris;
        }
    }
}
