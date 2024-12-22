using Kaktus.DB;
using System.Windows;
using System.Windows.Controls;

namespace Kaktus.Pages
{
    public partial class EditVistavkaPage : Page
    {
        private Vistavka _selectedVistavka;

        public EditVistavkaPage(Vistavka selectedVistavka)
        {
            InitializeComponent();
            _selectedVistavka = selectedVistavka;
            LoadVistavkaData();
        }

        private void LoadVistavkaData()
        {
            DataPicker.SelectedDate = _selectedVistavka.Data;
            MestoTextBox.Text = _selectedVistavka.Mesto;
            NagradaTextBox.Text = _selectedVistavka.Nagrada;
            KomentTextBox.Text = _selectedVistavka.Koment;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MestoTextBox.Text) || string.IsNullOrWhiteSpace(NagradaTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _selectedVistavka.Data = DataPicker.SelectedDate;
            _selectedVistavka.Mesto = MestoTextBox.Text;
            _selectedVistavka.Nagrada = NagradaTextBox.Text;
            _selectedVistavka.Koment = KomentTextBox.Text;

            ConnectionClass.connect.SaveChanges();
            MessageBox.Show("Изменения сохранены.", "Редактирование", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new VistavkaPage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new VistavkaPage());
        }
    }
}
