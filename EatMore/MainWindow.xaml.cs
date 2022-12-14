using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.IO;
using System.Windows.Media;
using Typography.OpenFont.Tables;

namespace EatMore
{
    /// <summary>
    /// Interaction logic for test.xaml
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



        private void HomeSide_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var HomeSideColor = (Brush)converter.ConvertFromString("#FF5733");
            HomeSide.Visibility = Visibility.Visible;
            ButtonHomeSide.Foreground = HomeSideColor;

            ButtonPizzaSide.Foreground = new SolidColorBrush(Colors.LightGray);
            ButtonDrikkevareSide.Foreground = new SolidColorBrush(Colors.LightGray);
            PizzaSide.Visibility = Visibility.Hidden;
            DrikkeSide.Visibility = Visibility.Hidden;
        }

        


        private void PizzaSide_Click(object sender, RoutedEventArgs e)
        {
            var converter = new System.Windows.Media.BrushConverter();
            var PizzaSideColor = (Brush)converter.ConvertFromString("#FF4C70");

            PizzaSide.Visibility = Visibility.Visible;
            ButtonPizzaSide.Foreground = PizzaSideColor;

            ButtonDrikkevareSide.Foreground = new SolidColorBrush(Colors.LightGray);
            ButtonHomeSide.Foreground = new SolidColorBrush(Colors.LightGray);
            HomeSide.Visibility = Visibility.Hidden;
            DrikkeSide.Visibility = Visibility.Hidden;
        }

        private void DrikkeSide_Click(object sender, RoutedEventArgs e)
        {
            DrikkeSide.Visibility = Visibility.Visible;
            ButtonDrikkevareSide.Foreground = new SolidColorBrush(Colors.Cyan);

            ButtonPizzaSide.Foreground = new SolidColorBrush(Colors.LightGray);
            ButtonHomeSide.Foreground = new SolidColorBrush(Colors.LightGray);
            PizzaSide.Visibility = Visibility.Hidden;
            HomeSide.Visibility = Visibility.Hidden;
        }

        

        /// Redigering af Pizza fra Menu
        private void EditPizzaMenu(object sender, RoutedEventArgs e)
        {
            DAL dal = new DAL();
            Button b = (Button)sender;


            if (b != null)
            {
                PizzaPresenter m = (PizzaPresenter)b.DataContext;
                if (m.ID < 49)
                {
                    double normalpris = m.Pris;
                    foreach (var item in vm._LocalPizza)
                    {
                        if (item.ID == m.ID)
                        {
                            m.Pris = item.Pris;
                        }
                    }

                    Pizza pizza = new Pizza(m.ID, m.Nummer, m.Navn, new ObservableCollection<Top>(m.ToppingOver), m.Pris, m.Antal, m.customID);
                    double realpris = m.Pris;


                    dinPizza nyside = new dinPizza(pizza, realpris);
                    nyside.ShowDialog();

                    int counter = 0;
                    if (nyside.nyPizza != null)
                    {
                        ///Udregner toppings pris hver gang man har redigeret en Pizza
                        foreach (var topping in pizza.Top)
                        {
                            realpris += topping.pris;
                        }
                        m.Pris = realpris * m.Antal;
                        m.ToppingOver = nyside.nyPizza.Top;


                        StringBuilder sb = new StringBuilder("");
                        foreach (var topping2 in pizza.Top)
                        {
                            sb.Append(topping2.Navn);
                            counter++;
                            if (pizza.Top.Count != counter)
                            {
                                if (counter == pizza.Top.Count - 1)
                                {
                                    sb.Append(" og ");

                                }
                                else { sb.Append(", "); }
                            }
                        }
                        m.Beskrivelse = sb.ToString();


                        var piz = (vm._OrderListe.Where(p => p.customID == m.customID).FirstOrDefault());

                        if (piz != null)
                        {
                            piz = new PizzaPresenter(nyside.nyPizza);
                        }

                        vm.TotalPrisUpdate();
                        vm.AntalUpdate();
                    }
                    else ///Hvis man anullere sin redigering (pris tilbage til den normale)
                    {
                        m.Pris = normalpris;
                    }
                }
            }
        }


        /// Tilføj en pizza + toppings
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
        { /// Tilføj antal med metoder til: Antal, Pris og totalPris updatering

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
        { /// Fjern antal med metoder til: Antal, Pris og totalPris updatering
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

        private void SletPizza_Click(object sender, MouseButtonEventArgs e)
        { ///Fjerne selve pizza'en fra Order Liste
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
        { ///Fjerner alt på Order Listen
            vm.ClearOrder();
            vm.TotalPrisUpdate();
            vm.AntalUpdate();
        }





        private void Drik_Click(object sender, RoutedEventArgs e)
        { ///Tilføjning af 1.5L driks
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
        { ///Tilføjning af 0.5L driks
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
        { ///Tilføjning af andre drikkevare
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


        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

