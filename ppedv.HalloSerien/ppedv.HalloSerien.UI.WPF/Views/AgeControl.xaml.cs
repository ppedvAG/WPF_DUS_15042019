using System;
using System.Collections.Generic;
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

namespace ppedv.HalloSerien.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for AgeControl.xaml
    /// </summary>
    public partial class AgeControl : UserControl
    {

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof(int), typeof(AgeControl), new PropertyMetadata(77, PropChange));

        private static void PropChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((AgeControl)d).tb1.Text = ((int)e.NewValue).ToString();
        }

        public AgeControl()
        {
            InitializeComponent();
            SetValue(BackgroundProperty, new SolidColorBrush(Colors.GreenYellow));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Age++;
        }
    }
}
