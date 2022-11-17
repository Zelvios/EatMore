using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatMore
{
    public class dinPizzaViewModel : INotifyPropertyChanged
    {
        private double _realpris;
        public double realpris
        {
            get { return _realpris; }
            set
            {
                _realpris = value;
                OnPropertyChanged("realpris");
            }
        }



        private double _Antal;
        public double Antal
        {
            get { return _Antal; }
            set
            {
                if (value < 1) { value = 1; }
                {
                    _Antal = value;
                    OnPropertyChanged("Antal");
                }
            }
        }





        DAL dal;
        private Pizza _pizza;
        public Pizza EditPizza
        {
            get { return _pizza; }
            set { _pizza = value; }
        }

        public ObservableCollection<Top> top { get; private set; }




        public dinPizzaViewModel(Pizza pizza)
        {
            _pizza = pizza;
            foreach (Top top in _pizza.Top)
            {
                realpris += top.pris;

            }

            Antal = _pizza.Antal;
            realpris += _pizza.Pris;
            dal = new DAL();
            top = dal.Toppings_Get();
        }




        public void homie(Pizza pizza)
        {
            for (int p = pizza.Top.Count - 1; p >= 0; p--)
            {
                for (int i = top.Count - 1; i >= 0; i--)
                {
                    if (top[i].ID == pizza.Top[p].ID)
                    {
                        top.RemoveAt(i);
                    }
                }
            }
        }

        public void top_add(Top topping)
        {
            for (int i = top.Count - 1; i >= 0; i--)
            {
                if (top[i].ID == topping.ID)
                {
                    realpris += top[i].pris;
                    EditPizza.Top.Add(topping);
                    break;
                }

            }
        }

        public void top_delete(Top topping)
        {
            for (int i = top.Count - 1; i >= 0; i--)
            {
                if (top[i].ID == topping.ID)
                {
                    top.Remove(topping);

                    break;
                }
            }
        }


        public void top_add1(Top topping)
        {
            for (int i = EditPizza.Top.Count - 1; i >= 0; i--)
            {
                if (EditPizza.Top[i].ID == topping.ID)
                {
                    top.Add(topping);

                    break;
                }

            }
        }


        public void top_delete1(Top topping)
        {
            for (int i = EditPizza.Top.Count - 1; i >= 0; i--)
            {
                if (EditPizza.Top[i].ID == topping.ID)
                {
                    realpris = realpris - EditPizza.Top[i].pris;
                    EditPizza.Top.Remove(topping);
                    break;
                }
            }
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
