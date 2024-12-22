using Kaktus.DB;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Kaktus.Pages
{
    public partial class VistavkaPage : Page
    {
        public VistavkaPage()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            VistavkaDataGrid.ItemsSource = ConnectionClass.connect.Vistavka.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddVistavkaPage());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedVistavka = VistavkaDataGrid.SelectedItem as Vistavka;
            if (selectedVistavka != null)
            {
                NavigationService.Navigate(new EditVistavkaPage(selectedVistavka));
            }
            else
            {
                MessageBox.Show("Выберите выставку для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedVistavka = VistavkaDataGrid.SelectedItem as Vistavka;
            if (selectedVistavka != null)
            {
                if (MessageBox.Show("Удалить выставку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConnectionClass.connect.Vistavka.Remove(selectedVistavka);
                    ConnectionClass.connect.SaveChanges();
                    Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите выставку для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закрытие текущего окна, если это окно
            Window.GetWindow(this).Close();
        }
    }
}
