using Kaktus.DB;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class EditCactus : Page
    {
        private DB.Cactus _selectedCactus;

        public EditCactus(DB.Cactus selectedCactus)
        {
            InitializeComponent();
            _selectedCactus = selectedCactus;
            LoadCactusData();
        }

        // Загрузка данных кактуса в текстовые поля для редактирования
        private void LoadCactusData()
        {
            VidTextBox.Text = _selectedCactus.Vid;
            ProishozhdenieTextBox.Text = _selectedCactus.Proishozhdenie;
            VozrastTextBox.Text = _selectedCactus.Vozrast.ToString();
            StoimostTextBox.Text = _selectedCactus.Stoimost.ToString();
            InstrukciyaTextBox.Text = _selectedCactus.Instrukciya;
        }

        // Обработка сохранения изменений
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(VidTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProishozhdenieTextBox.Text) ||
                string.IsNullOrWhiteSpace(VozrastTextBox.Text) ||
                string.IsNullOrWhiteSpace(StoimostTextBox.Text) ||
                string.IsNullOrWhiteSpace(InstrukciyaTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(VozrastTextBox.Text, out int vozrast))
            {
                MessageBox.Show("Возраст должен быть целым числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(StoimostTextBox.Text, out decimal stoimost))
            {
                MessageBox.Show("Стоимость должна быть числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создание нового кактуса
            _selectedCactus.Vid = VidTextBox.Text;
            _selectedCactus.Proishozhdenie = ProishozhdenieTextBox.Text;
            _selectedCactus.Vozrast = vozrast; // Теперь корректно присваивается возраст
            _selectedCactus.Stoimost = Convert.ToInt32(stoimost); // Теперь корректно присваивается стоимость
            _selectedCactus.Instrukciya = InstrukciyaTextBox.Text;

            // Сохранение изменений в базе данных
            ConnectionClass.connect.SaveChanges();

            MessageBox.Show($"Кактус {_selectedCactus.Vid} был успешно обновлен.", "Обновление", MessageBoxButton.OK, MessageBoxImage.Information);

            // Возврат на предыдущую страницу после редактирования
            NavigationService.Navigate(new Cactus());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cactus());
        }
    }
}
