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

namespace Kaktus.Pages
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            DDD.Visibility = Visibility.Hidden;
            VVV.Visibility = Visibility.Hidden;
            SSS.Visibility = Visibility.Hidden;
            Frame.NavigationService.Navigate(new Pages.Cactus());
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            DDD.Visibility = Visibility.Hidden;
            VVV.Visibility = Visibility.Hidden;
            SSS.Visibility = Visibility.Hidden;
            Frame.NavigationService.Navigate(new VistavkaPage());
        }

        private void SSS_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            DDD.Visibility = Visibility.Hidden;
            VVV.Visibility = Visibility.Hidden;
            SSS.Visibility = Visibility.Hidden;
            Frame.NavigationService.Navigate(new VistavkaCactusPage());
        }
    }
}
