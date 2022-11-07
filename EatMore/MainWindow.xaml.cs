using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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


        private void pizzaButton_Click(object sender, RoutedEventArgs e)
        {
            pizzaBox.Visibility = Visibility.Visible;
            drikBox.Visibility = Visibility.Hidden;
        }

        private void drik_Click(object sender, RoutedEventArgs e)
        {
            pizzaBox.Visibility = Visibility.Hidden;
            drikBox.Visibility = Visibility.Visible;
        }

        private void Tilføj_Pizza(object sender, RoutedEventArgs e)
        {

            Button b = (Button)sender;

            if (b != null)
            {
                PizzaPresenter m = (PizzaPresenter)b.DataContext;
                if (m != null)
                {
                    DAL d = new DAL();

                    Pizza oldPizza = null;
                    Pizza newPizza = null;

                    foreach (var pizza in d.Get())
                    {
                        if (pizza.ID == m.ID)
                        {
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
                        vm.testpizzza(newPizza);
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
                    //m.Antal++;
                    //m.Pris = m.Antal * m.Pris;
                    vm.AddAntal(m);


                }
            }
        }
        private void RemoveAntal_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
