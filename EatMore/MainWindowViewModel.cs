﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EatMore
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        DAL dal;

        public ObservableCollection<PizzaPresenter> Pizza { get; set; } = new ObservableCollection<PizzaPresenter>();

        public ObservableCollection<Pizza> _Order { get; set; } = new ObservableCollection<Pizza>();

        public ObservableCollection<PizzaPresenter> _OrderListe { get; set; } = new ObservableCollection<PizzaPresenter>();

        public ObservableCollection<Pizza> _LocalPizza { get; private set; }

        public ObservableCollection<Drik> _LocalDrik { get; private set; }
        public ObservableCollection<DrikHalv> _LocalDrikHalv { get; private set; }
        public ObservableCollection<DrikAndet> _LocalDrikAndet { get; private set; }

        private int _TotalAntal;

        public int TotalAntal
        {
            get { return _TotalAntal; }
            set
            {
                _TotalAntal = value;
                OnPropertyChanged("TotalAntal");
            }
        }


        private double _TotalPris;

        public double TotalPris
        {
            get { return _TotalPris; }
            set
            {
                _TotalPris = value;
                OnPropertyChanged("TotalPris");
            }
        }



        // -----------------------------------------------
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


        public void addpizzza(Pizza pizza)
        {
            _Order.Add(pizza);
            _OrderListe.Add(new PizzaPresenter(pizza));
        }

        public void AntalUpdate()
        {
            TotalAntal = 0;
            for (int i = _OrderListe.Count - 1; i >= 0; i--)
            {
                TotalAntal += _OrderListe[i].Antal;
            }
        }


        public void TotalPrisUpdate()
        {
            TotalPris = 0;
            foreach (var p in _OrderListe)
            {
                if (p != null)
                {
                    TotalPris = TotalPris + p.Pris;
                }
            }
        }

        public void ClearOrder()
        {
            _OrderListe.Clear();
        }
        // 
        public void AddAntal(PizzaPresenter item)
        {
            foreach (var p in _OrderListe)
            {
                if (p != null)
                {
                    if (p.ID == item.ID)
                    {
                        if (p.ID > 48)
                        {

                            item.Antal++;
                            item.Pris = item.Pris + item.BasePris;
                        }

                        if (p.ID < 48)
                        {
                            if (p.ToppingOver == item.ToppingOver)
                            {
                                item.BasePris = item.Pris;
                                item.BasePris /= item.Antal;


                                foreach (var top in item.ToppingOver)
                                {
                                    item.BasePris -= top.pris;
                                }

                                foreach (var top in item.ToppingOver)
                                {
                                    item.BasePris += top.pris;
                                }
                                item.Antal++;
                                item.Pris += item.BasePris;
                            }
                        }

                    }
                }
            }
        }



        public void RemoveAntal(PizzaPresenter item)
        {
            foreach (var p in _OrderListe)
            {
                if (p != null)
                {
                    if (p.ID == item.ID)
                    {
                        if (p.Antal > 1)
                        {
                            if (p.ID > 48)
                            {
                                item.Antal--;
                                item.Pris = item.Pris - item.BasePris;
                            }
                            if (p.ID < 48)
                            {

                                item.BasePris = item.Pris;
                                item.BasePris /= item.Antal;


                                foreach (var top in item.ToppingOver)
                                {
                                    item.BasePris -= top.pris;
                                }

                                foreach (var top in item.ToppingOver)
                                {
                                    item.BasePris += top.pris;
                                }
                                item.Antal--;
                                item.Pris = item.Pris - item.BasePris;
                            }

                        }
                    }
                }
            }
        }

        public void AddlDrik(Drik d)
        {
            ObservableCollection<Top> s;
            s = new ObservableCollection<Top>();
            s.Add(new Top(d.ID, "ttt", d.Pris));

            bool check = false;

            for (int i = _OrderListe.Count - 1; i >= 0; i--)
            {
                if (d.ID == _OrderListe[i].ID)
                {
                    check = true;


                    _OrderListe[i].Antal++;
                    _OrderListe[i].Pris += d.Pris;

                }
            }
            if (check == false)
            {
                d.BasePris = d.Pris;
                _OrderListe.Add(new PizzaPresenter(d.ID, 0, d.Navn, new ObservableCollection<Top>(s), d.Pris, d.Antal, 0, d.BasePris));

            }

        }


        public void AddlDrikHalv(DrikHalv d)
        {
            ObservableCollection<Top> s;
            s = new ObservableCollection<Top>();
            s.Add(new Top(d.ID, d.L, d.Pris));

            bool check = false;

            for (int i = _OrderListe.Count - 1; i >= 0; i--)
            {
                if (d.ID == _OrderListe[i].ID)
                {
                    check = true;


                    _OrderListe[i].Antal++;
                    _OrderListe[i].Pris += d.Pris;

                }
            }
            if (check == false)
            {
                d.BasePris = d.Pris;
                _OrderListe.Add(new PizzaPresenter(d.ID, 0, d.Navn, s, d.Pris, d.Antal, 0, d.BasePris));

            }

        }

        public void AddlDrikAndet(DrikAndet d)
        {
            ObservableCollection<Top> s;
            s = new ObservableCollection<Top>();
            s.Add(new Top(d.ID, d.L, d.Pris));

            bool check = false;

            for (int i = _OrderListe.Count - 1; i >= 0; i--)
            {
                if (d.ID == _OrderListe[i].ID)
                {
                    check = true;


                    _OrderListe[i].Antal++;
                    _OrderListe[i].Pris += d.Pris;

                }
            }
            if (check == false)
            {
                d.BasePris = d.Pris;
                _OrderListe.Add(new PizzaPresenter(d.ID, 0, d.Navn, new ObservableCollection<Top>(s), d.Pris, d.Antal, 0, d.BasePris));

            }

        }



        public void DeletePizza(PizzaPresenter pizza)
        {
            _OrderListe.Remove(pizza);
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
