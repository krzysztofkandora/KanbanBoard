using System;
using System.Windows;
using System.Windows.Controls;

namespace kanbanboard
{
    public partial class AddTaskWindow : Window
    {
        public Karta NewTask { get; private set; }

        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz dane z formularza
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            string status = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Tytuł i status są wymagane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Utwórz nowe zadanie
            NewTask = new Karta
            {
                title = title,
                description = description,
                creation_date = DateTime.Now,
                assigned_user = "Nieprzypisany", // Dodać wybór użytkownika 
                Status = status
            };

            // Zamknij okno
            DialogResult = true;
            Close();
        }
    }
}
