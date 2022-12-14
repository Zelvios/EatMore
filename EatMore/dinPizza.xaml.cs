using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Printing;
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

namespace EatMore
{
    /// <summary>
    /// Interaction logic for dinPizza.xaml
    /// </summary>
    public partial class dinPizza : Window
    {

        dinPizzaViewModel viewModel;
        public Pizza nyPizza { get; set; }

        //RealPris = den pris med topping som kommer med over fra mainwindow
        public dinPizza(Pizza pizza, double realpris)
        {
            viewModel = new dinPizzaViewModel(pizza);
            this.DataContext = viewModel;
            viewModel.CountR(pizza);
            InitializeComponent();
        }

        

        private void Tilføj_Tilbe(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Top m = (Top)b.DataContext;
                if (m != null)
                {
                    viewModel.top_add(m);
                    viewModel.top_delete(m);
                    if (viewModel.EditPizza.Top.Count > 0)
                    {
                        viewModel.ManglerTop = "";
                    }
                }
            }
        }
        private void Fjern_Tilbe(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (b != null)
            {
                Top m = (Top)b.DataContext;
                if (m != null)
                {
                    viewModel.top_add1(m);
                    viewModel.top_delete1(m);
                }
                if (viewModel.EditPizza.Top.Count == 0)
                {
                    viewModel.ManglerTop = "Du skal midst have 1 topping.";
                }
            }
        }

       
        private void AddPizza(object sender, RoutedEventArgs e)
        {
            if (viewModel.EditPizza.Top.Count > 0)
            {
                nyPizza = viewModel.EditPizza;
                nyPizza.customID++;
                DialogResult = true;
            }
            else
            {
                viewModel.ManglerTop = "HEY!!! du skal midst have 1 topping.";
            }
        }

        private void FjernPizza(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void WindowClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        //private void AntalTil_Click(object sender, RoutedEventArgs e)
        //{
        //    Button b = (Button)sender;
        //    if (b != null)
        //    {

        //        viewModel.Antal++;
        //        if (viewModel.Antal > 0)
        //            viewModel.realpris += Here;
        //    }
        //}
        //private void AntalFjern_Click(object sender, RoutedEventArgs e)
        //{
        //    Button b = (Button)sender;
        //    if (b != null)
        //    {
        //        viewModel.Antal--;
        //        if (viewModel.Antal > 0)
        //            viewModel.realpris -= Here;
        //    }
        //}
    }
}
