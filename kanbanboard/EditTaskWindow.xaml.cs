using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace kanbanboard
{
    public partial class EditTaskWindow : Window, LuSchZadania
    {
        private readonly KanbanDbContext _dbContext;
        private Karta taskToEdit;

        public EditTaskWindow(Karta task, KanbanDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext; 
            taskToEdit = task;

            LoadUsers();
            PopulateFields();
        }

    public void LoadUsers()
        {
            var users = _dbContext.users.ToList();
            UserComboBox.ItemsSource = users;
        }


        public void SaveChanges()
        {
            var selectedUser = UserComboBox.SelectedItem as Uzytkownik;
            var selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();

            // Weryfikacja danych
            if (string.IsNullOrWhiteSpace(TaskTitleTextBox.Text) || selectedUser == null || string.IsNullOrEmpty(selectedStatus))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola.");
                return;
            }

            // Aktualizacja danych zadania
            taskToEdit.title = TaskTitleTextBox.Text;
            taskToEdit.description = TaskDescriptionTextBox.Text;
            taskToEdit.assigned_user = selectedUser.login;
            taskToEdit.Status = selectedStatus;

            // Zapisanie zmian w bazie danych
            _dbContext.Zadania.Update(taskToEdit);
            _dbContext.SaveChanges();

            MessageBox.Show("Zadanie zostało zaktualizowane.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            this.Close(); 
        }


        private void PopulateFields()
        {
            TaskTitleTextBox.Text = taskToEdit.title;
            TaskDescriptionTextBox.Text = taskToEdit.description;

            // Ustawienie wybranego użytkownika
            UserComboBox.SelectedItem = _dbContext.users.FirstOrDefault(u => u.login == taskToEdit.assigned_user);

            // Ustawienie wybranego statusu
            StatusComboBox.SelectedItem = StatusComboBox.Items.Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == taskToEdit.Status);
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            SaveChanges();        }
    }
}
