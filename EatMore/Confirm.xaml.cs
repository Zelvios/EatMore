using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EatMore
{
    /// <summary>
    /// Interaction logic for Confirm.xaml
    /// </summary>
    public partial class Confirm : Window
    {
        ConfirmViewModel ViewModel;
        public Confirm(ObservableCollection<PizzaPresenter> menu, double TotalPris)
        {
            ViewModel = new ConfirmViewModel(menu, TotalPris);
            this.DataContext = ViewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var saveFile = JsonConvert.SerializeObject(ViewModel.Order, Formatting.Indented);
            File.WriteAllText("Order.json", saveFile);
            this.Close();
        }

        private void Anullere_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
