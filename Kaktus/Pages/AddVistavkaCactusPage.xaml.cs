using Kaktus.DB;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class AddVistavkaCactusPage : Page
    {
        public AddVistavkaCactusPage()
        {
            InitializeComponent();
        }

        // Добавление кактуса на выставку
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int cactusId, vistavkaId;

            // Проверка ввода
            if (!int.TryParse(CactusIDTextBox.Text, out cactusId) || !int.TryParse(VistavkaIDTextBox.Text, out vistavkaId))
            {
                MessageBox.Show("Пожалуйста, введите корректные ID для кактуса и выставки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создание новой записи
            var newVistavkaCactus = new Vistavka_Caktusov
            {
                ID_Cactus = cactusId,
                ID_Vistavka = vistavkaId
            };

            // Добавление в базу данных
            ConnectionClass.connect.Vistavka_Caktusov.Add(newVistavkaCactus);
            ConnectionClass.connect.SaveChanges();

            MessageBox.Show("Кактус добавлен на выставку.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            // Возврат на предыдущую страницу
            NavigationService.Navigate(new VistavkaCactusPage());
        }

        // Кнопка "Назад"
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VistavkaCactusPage());

        }
    }
}
