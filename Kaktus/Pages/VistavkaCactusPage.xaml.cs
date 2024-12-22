using Kaktus.DB;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class VistavkaCactusPage : Page
    {
        public VistavkaCactusPage()
        {
            InitializeComponent();
            LoadData();
        }

        // Загрузка данных о кактусах на выставках
        private void LoadData()
        {
            VistavkaCactiDataGrid.ItemsSource = ConnectionClass.connect.Vistavka_Caktusov.ToList();
        }

        // Добавление новой записи
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddVistavkaCactusPage());
        }

        // Редактирование выбранной записи
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedVistavkaCactus = VistavkaCactiDataGrid.SelectedItem as Vistavka_Caktusov;
            if (selectedVistavkaCactus != null)
            {
                NavigationService.Navigate(new EditVistavkaCactusPage(selectedVistavkaCactus));
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Удаление выбранной записи
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedVistavkaCactus = VistavkaCactiDataGrid.SelectedItem as Vistavka_Caktusov;
            if (selectedVistavkaCactus != null)
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить кактус с ID {selectedVistavkaCactus.ID_Cactus} с выставки?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ConnectionClass.connect.Vistavka_Caktusov.Remove(selectedVistavkaCactus);
                    ConnectionClass.connect.SaveChanges();
                    LoadData(); // Обновляем таблицу после удаления
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Кнопка "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закрытие текущего окна, если это окно
            Window.GetWindow(this).Close();
        }
    }
}
