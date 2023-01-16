using System;
using System.Collections.Generic;
using System.IO;
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
using System.IO;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using EatMore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace OrdrerWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrderWindowViewModel vm;


        public MainWindow()
        {
            vm = new OrderWindowViewModel();
            this.DataContext = vm;
            InitializeComponent();
        }

        private void Ordere(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Debug.WriteLine("test");
                string[] FileLoad = (string[])e.Data.GetData(DataFormats.FileDrop);
                string Files = File.ReadAllText(FileLoad[0]);
                var filJson = JsonConvert.DeserializeObject<ObservableCollection<OrderTing>>(Files);
                vm.addordere(filJson);

            }
        }
        private void fjern(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b != null)
            {
                JsonFileInfo m = (JsonFileInfo)b.DataContext;
                if (m != null)
                {
                    vm.fjern(m);
                }
            }
        }
    }
}
