using Kaktus.DB;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class AddVistavkaPage : Page
    {
        public AddVistavkaPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MestoTextBox.Text) || string.IsNullOrWhiteSpace(NagradaTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newVistavka = new Vistavka
            {
                Data = DataPicker.SelectedDate,
                Mesto = MestoTextBox.Text,
                Nagrada = NagradaTextBox.Text,
                Koment = KomentTextBox.Text
            };

            ConnectionClass.connect.Vistavka.Add(newVistavka);
            ConnectionClass.connect.SaveChanges();
            MessageBox.Show("Выставка добавлена.", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.Navigate(new VistavkaPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VistavkaPage());
        }
    }
}
