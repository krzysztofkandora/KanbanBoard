using System;
using System.Windows;
using System.Windows.Controls;

namespace kanbanboard
{
    public partial class AddTaskWindow : Window
    {
        private KanbanDbContext _dbContext;
        public Karta NewTask { get; private set; }
        public AddTaskWindow()
        {
            InitializeComponent();
            _dbContext = new KanbanDbContext();
            LoadUsers();
            StatusComboBox.SelectedIndex = 0; // Ustaw domyślny status
        }

        private void LoadUsers()
        {
            var users = _dbContext.users.ToList();
            UserComboBox.ItemsSource = users;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserComboBox.SelectedItem as Uzytkownik;
            var selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();

            if (string.IsNullOrWhiteSpace(TaskTitleTextBox.Text) || selectedUser == null || string.IsNullOrEmpty(selectedStatus))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola.");
                return;
            }

            NewTask = new Karta
            {
                title = TaskTitleTextBox.Text,
                description = TaskDescriptionTextBox.Text,
                creation_date = DateTime.Now,
                assigned_user = $"{selectedUser.login}",
                Status = selectedStatus
            };

            DialogResult = true; // Ustaw wartość zwracaną okna na true
            this.Close();
        }

    }
}