using Kaktus.DB;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class Cactus : Page
    {
        public Cactus()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            asd.ItemsSource = null;
            asd.ItemsSource = ConnectionClass.connect.Cactus.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGrid
            if (asd.SelectedItem == null)
            {
                MessageBox.Show("Выберите кактус для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Получаем выбранный кактус
            var selectedCactus = asd.SelectedItem as DB.Cactus;

            if (selectedCactus != null)
            {
                // Проверяем, участвует ли кактус в выставке
                if (ConnectionClass.connect.Vistavka_Caktusov.Any(ce => ce.ID_Cactus == selectedCactus.Cactus_ID))
                {
                    MessageBox.Show("Этот кактус уже участвует в выставке и не может быть удален.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Подтверждение удаления
                if (MessageBox.Show($"Удалить кактус {selectedCactus.Vid}?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // Удаляем кактус
                    ConnectionClass.connect.Cactus.Remove(selectedCactus);
                    ConnectionClass.connect.SaveChanges();

                    // Обновляем таблицу
                    Refresh();

                    MessageBox.Show($"Кактус {selectedCactus.Vid} был успешно удален.", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие страницы добавления нового кактуса
            NavigationService.Navigate(new AddCactus());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, выбран ли кактус
            if (asd.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите кактус для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Получаем выбранный кактус
            var selectedCactus = asd.SelectedItem as DB.Cactus;

            // Переход на страницу редактирования с передачей данных выбранного кактуса
            NavigationService.Navigate(new EditCactus(selectedCactus));

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
