using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;

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
                wc.Encoding = Encoding.UTF8;
                var url = $"https://www.googleapis.com/books/v1/volumes?q={suchTb.Text}";
                var json = wc.DownloadString(url);
                var bookResult = JsonConvert.DeserializeObject<BookResults>(json);

                    booksLb.ItemsSource = bookResult.items.Select(x => x.volumeInfo);
            }
        }
    }
}
