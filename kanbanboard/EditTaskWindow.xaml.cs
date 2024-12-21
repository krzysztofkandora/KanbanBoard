using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kanbanboard
{
    public partial class EditTaskWindow : Window
    {
        private KanbanDbContext _dbContext;
        private Karta taskToEdit;

        public EditTaskWindow(Karta task)
        {
            InitializeComponent();
            _dbContext = new KanbanDbContext();
            taskToEdit = task;

            LoadUsers();
            PopulateFields();
        }

        private void LoadUsers()
        {
            var users = _dbContext.users.ToList();
            UserComboBox.ItemsSource = users;
        }

        private void PopulateFields()
        {
            TaskTitleTextBox.Text = taskToEdit.title;
            TaskDescriptionTextBox.Text = taskToEdit.description;
            UserComboBox.SelectedItem = _dbContext.users.FirstOrDefault(u => u.login == taskToEdit.assigned_user);
            StatusComboBox.SelectedItem = StatusComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == taskToEdit.Status);
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UserComboBox.SelectedItem as Uzytkownik;
            var selectedStatus = (StatusComboBox.SelectedItem as ComboBoxItem)?.Tag.ToString();

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

            _dbContext.Zadania.Update(taskToEdit);
            _dbContext.SaveChanges();

            MessageBox.Show("Zadanie zostało zaktualizowane.");
            this.Close();
        }
    }
}