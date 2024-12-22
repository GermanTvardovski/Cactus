using Kaktus.DB;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class AddCactus : Page
    {
        public AddCactus()
        {
            InitializeComponent();

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на заполнение всех полей
            if (string.IsNullOrWhiteSpace(VidTextBox.Text) ||
                string.IsNullOrWhiteSpace(ProishozhdenieTextBox.Text) ||
                string.IsNullOrWhiteSpace(VozrastTextBox.Text) ||
                string.IsNullOrWhiteSpace(StoimostTextBox.Text) ||
                string.IsNullOrWhiteSpace(InstrukciyaTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Проверка корректности данных
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
            var newCactus = new DB.Cactus
            {
                Vid = VidTextBox.Text,
                Proishozhdenie = ProishozhdenieTextBox.Text,
                Vozrast = vozrast, // Теперь корректно присваивается возраст
                Stoimost = Convert.ToInt32(stoimost), // Теперь корректно присваивается стоимость
                Instrukciya = InstrukciyaTextBox.Text
            };

            // Добавление нового кактуса в базу данных
            ConnectionClass.connect.Cactus.Add(newCactus);
            ConnectionClass.connect.SaveChanges();

            MessageBox.Show($"Кактус {newCactus.Vid} успешно добавлен.", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);

            // Возврат на предыдущую страницу после добавления
            NavigationService.Navigate(new Cactus());
            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cactus());
        }
    }
}
