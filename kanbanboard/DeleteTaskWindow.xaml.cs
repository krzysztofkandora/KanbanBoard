using System.Windows;

namespace kanbanboard
{
    public partial class DeleteTaskWindow : Window
    {
        private KanbanDbContext _dbContext;

        public DeleteTaskWindow()
        {
            InitializeComponent();
            _dbContext = new KanbanDbContext();
            LoadTasks();
        }

        private void LoadTasks()
        {
            // Załaduj zadania do ListBox
            var tasks = _dbContext.Zadania.ToList();
            TaskListBox.ItemsSource = tasks;
        }

        private void DeleteSelectedTask_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz wybrane zadanie
            var selectedTask = TaskListBox.SelectedItem as Karta;
            if (selectedTask == null)
            {
                MessageBox.Show("Proszę wybrać zadanie do usunięcia.", "Brak wyboru", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Czy na pewno chcesz usunąć zadanie: \"{selectedTask.title}\"?",
                "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Usuń zadanie z bazy danych
                    _dbContext.Zadania.Remove(selectedTask);
                    _dbContext.SaveChanges();

                    MessageBox.Show("Zadanie zostało usunięte.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Odśwież listę zadań
                    LoadTasks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd podczas usuwania zadania: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}