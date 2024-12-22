using Kaktus.DB;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class EditVistavkaCactusPage : Page
    {
        private Vistavka_Caktusov _vistavkaCactus;

        public EditVistavkaCactusPage(Vistavka_Caktusov vistavkaCactus)
        {
            InitializeComponent();
            _vistavkaCactus = vistavkaCactus;
            LoadData();
        }

        // Загрузка данных в текстовые поля
        private void LoadData()
        {
            CactusIDTextBox.Text = _vistavkaCactus.ID_Cactus.ToString();
            VistavkaIDTextBox.Text = _vistavkaCactus.ID_Vistavka.ToString();
        }

        // Сохранение изменений
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int cactusId, vistavkaId;

            // Проверка ввода
            if (!int.TryParse(CactusIDTextBox.Text, out cactusId) || !int.TryParse(VistavkaIDTextBox.Text, out vistavkaId))
            {
                MessageBox.Show("Пожалуйста, введите корректные ID для кактуса и выставки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Обновление объекта
            _vistavkaCactus.ID_Cactus = cactusId;
            _vistavkaCactus.ID_Vistavka = vistavkaId;

            // Сохранение изменений в базе данных
            ConnectionClass.connect.SaveChanges();
            MessageBox.Show("Изменения успешно сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            // Возврат на предыдущую страницу
            NavigationService.GoBack();
        }

        // Кнопка "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
