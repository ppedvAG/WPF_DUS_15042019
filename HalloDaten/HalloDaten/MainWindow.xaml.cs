using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace HalloDaten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadBooks(object sender, RoutedEventArgs e)
        {
            using (var wc = new WebClient())
            {
                var url = $"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}";
                var json = wc.DownloadString(url);
                MessageBox.Show(json);
            }
        }
    }
}
