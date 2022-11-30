using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace EatMore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // View Model:
        MainWindowViewModel vm;


        public MainWindow()
        {
            vm = new MainWindowViewModel();
            this.DataContext = vm;

            InitializeComponent();
        }



        // Skifte mellem drik og Pizza:
        private void pizzaButton_Click(object sender, RoutedEventArgs e)
        {
            pizzaBox.Visibility = Visibility.Visible;
            drikBox.Visibility = Visibility.Hidden;
            pizzaButton.Background = Brushes.Gray;
            drik.Background = Brushes.LightBlue;
        }

        private void drik_Click(object sender, RoutedEventArgs e)
        {
            pizzaBox.Visibility = Visibility.Hidden;
            drikBox.Visibility = Visibility.Visible;
            drik.Background = Brushes.Gray;
            pizzaButton.Background = Brushes.LightBlue;
        }

        private void EditPizzaMenu(object sender, RoutedEventArgs e)
        {
            DAL dal = new DAL();
            Button b = (Button)sender;

           

            if (b != null)
            {
                PizzaPresenter m = (PizzaPresenter)b.DataContext;
                if (m != null)
                {
                    foreach (var item in vm._LocalPizza)
                    {
                        if (item.ID == m.ID)
                        {
                            m.Pris = item.Pris;
                        }
                    }
                    
                    Pizza pizza = new Pizza(m.ID, m.Nummer, m.Navn, new ObservableCollection<Top>( m.ToppingOver), m.Pris, m.Antal, m.customID);
                    double realpris = m.Pris;
                    

                    dinPizza nyside = new dinPizza(pizza, realpris);
                    nyside.ShowDialog();

                    if (nyside.nyPizza != null)
                    {
                        foreach (var topping in pizza.Top)
                        {
                            realpris += topping.pris;
                        }
                        m.Pris = realpris;
                        

                        var piz = (vm._OrderListe.Where(p => p.customID == m.customID).FirstOrDefault());

                        if (piz!= null)
                        {
                            piz = new PizzaPresenter(nyside.nyPizza);
                        }

                        vm.TotalPrisUpdate();
                        vm.AntalUpdate();
                    }
                }
            }
        }


        // Tilføj en pizza
        private void Tilføj_Pizza(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;

            if (b != null)
            {
                PizzaPresenter m = (PizzaPresenter)b.DataContext;
                if (m != null)
                {
                    DAL d = new DAL();

                    // 
                    Pizza oldPizza = null;
                    Pizza newPizza = null;

                    foreach (var pizza in d.Get())
                    {
                        if (pizza.ID == m.ID)
                        {

                            pizza.Top = new ObservableCollection<Top>(m.ToppingOver);

                            oldPizza = pizza;

                            PizzaPresenter p = new PizzaPresenter(pizza);
                            double realpris = p.Pris;
                            dinPizza nyside = new dinPizza(pizza, realpris);
                            nyside.ShowDialog();
                            newPizza = nyside.nyPizza;

                        }
                    }

                    if (newPizza != null && oldPizza != null)
                    {
                        double realpris = oldPizza.Pris;
                        oldPizza = newPizza;

                        Debug.WriteLine($"prisen er {realpris}");


                        newPizza.Pris = realpris;
                        vm.addpizzza(newPizza);
                        vm.TotalPrisUpdate();
                        vm.AntalUpdate();
                    }

                }
            }
        }


        private void AddAntal_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                PizzaPresenter m = (PizzaPresenter)b.DataContext;

                if (m != null)
                {

                    vm.AddAntal(m);
                    vm.TotalPrisUpdate();
                    vm.AntalUpdate();
                }
            }
        }
        private void RemoveAntal_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                PizzaPresenter m = (PizzaPresenter)b.DataContext;

                if (m != null)
                {

                    vm.RemoveAntal(m);
                    vm.TotalPrisUpdate();
                    vm.AntalUpdate();
                }
            }
        }

        private void SletPizza_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                PizzaPresenter m = (PizzaPresenter)b.DataContext;

                if (m != null)
                {
                    vm.DeletePizza(m);
                    vm.TotalPrisUpdate();
                    vm.AntalUpdate();
                }
            }
        }

        private void Fjern(object sender, RoutedEventArgs e)
        {
            vm.ClearOrder();
            vm.TotalPrisUpdate();
            vm.AntalUpdate();
        }





        private void Drik_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Drik m = (Drik)b.DataContext;

                if (m != null)
                {
                    vm.AddlDrik(m);
                    vm.TotalPrisUpdate();
                    vm.AntalUpdate();
                }
            }
        }
        private void DrikHalv_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                DrikHalv m = (DrikHalv)b.DataContext;

                if (m != null)
                {
                    vm.AddlDrikHalv(m);
                    vm.TotalPrisUpdate();
                    vm.AntalUpdate();
                }
            }
        }

        private void DrikAndet_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                DrikAndet m = (DrikAndet)b.DataContext;

                if (m != null)
                {
                    vm.AddlDrikAndet(m);
                    vm.TotalPrisUpdate();
                    vm.AntalUpdate();
                }
            }
        }

        private void Bestil_Click(object sender, RoutedEventArgs e)
        {
            if (vm._OrderListe.Count > 0)
            {
                Confirm bestilling = new Confirm(vm._OrderListe, vm.TotalPris);
                bestilling.ShowDialog();
            }
        }
    }
}
