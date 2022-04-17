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
using System.Windows.Threading;

namespace WpfApp2.View
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        DispatcherTimer timer = new DispatcherTimer();
        private void media_Loaded(object sender, RoutedEventArgs e)
        {
            media.Source = new Uri(Environment.CurrentDirectory + @"\giphy.gif");
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Start();


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            gridmenu.Visibility = gridlabel.Visibility = gridframe.Visibility = Visibility.Visible;
            media.Visibility = Visibility.Hidden;
            textloading.Visibility = Visibility.Hidden;

        }
    }
}
