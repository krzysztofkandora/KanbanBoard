using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace kanbanboard
{
    public interface LuSchZadania
    {
        void LoadUsers();   // Ładowanie użytkowników
        void SaveChanges(); // Zapisanie zmian w zadaniu
    }
    public interface ITaskAction
    {
        void Execute(object parameter);
    }

  
    public abstract class TaskActionBase : ITaskAction
    {
        protected KanbanDbContext DbContext { get; private set; }

        public TaskActionBase()
        {
            DbContext = new KanbanDbContext();
        }

        public abstract void Execute(object parameter);
    }

    public class AddTask : TaskActionBase
    {
        public override void Execute(object parameter)
        {
            var addTaskWindow = new AddTaskWindow();
            if (addTaskWindow.ShowDialog() == true)
            {
                var newTask = addTaskWindow.NewTask;
                if (newTask != null)
                {
                    DbContext.Zadania.Add(newTask);
                }
            }
        }
    }

    public class EditTask : TaskActionBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Karta task)
            {
                var editTaskWindow = new EditTaskWindow(task);
                editTaskWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nie wybrano zadania do edycji.");
            }
        }
    }

    public class ShowTaskDetails : TaskActionBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Karta selectedTask)
            {
                var taskDetailsWindow = new TaskDetailsWindow(selectedTask);
                taskDetailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Nie udało się otworzyć szczegółów zadania.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class DeleteTask : TaskActionBase
    {
        public override void Execute(object parameter)
        {
            var deleteTaskWindow = new DeleteTaskWindow();
            deleteTaskWindow.ShowDialog();
        }
    }

    public partial class MainWindow : Window
    {
        private KanbanDbContext _dbContext;

        public MainWindow()
        {
            InitializeComponent();
            _dbContext = new KanbanDbContext();
            LoadKanbanData();
        }

        private void LoadKanbanData()
        {
            var wszystkieZadania = _dbContext.Zadania.ToList();
            var kanbanBoard = new KanbanBoard
            {
                Nowe = wszystkieZadania.Where(z => z.Status == "Nowe").ToList(),
                Zaplanowane = wszystkieZadania.Where(z => z.Status == "Zaplanowane").ToList(),
                WTrakcie = wszystkieZadania.Where(z => z.Status == "WTrakcie").ToList(),
                Testowanie = wszystkieZadania.Where(z => z.Status == "Testowanie").ToList(),
                Ukonczone = wszystkieZadania.Where(z => z.Status == "Ukonczone").ToList()
            };

            KanbanDataGrid.ItemsSource = new List<KanbanBoard> { kanbanBoard };
        }

        private void ExecuteTaskAction(ITaskAction action, object parameter = null)
        {
            action.Execute(parameter);
            LoadKanbanData();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            ExecuteTaskAction(new AddTask());
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var task = button?.DataContext as Karta;
            ExecuteTaskAction(new EditTask(), task);
        }

        private void ShowTaskDetails_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var task = button?.CommandParameter as Karta;
            ExecuteTaskAction(new ShowTaskDetails(), task);
        }

        private void DeleteTaskMenu_Click(object sender, RoutedEventArgs e)
        {
            ExecuteTaskAction(new DeleteTask());
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadKanbanData();
        }
    }

    public class Uzytkownik
    {
        [Key]
        public string login { get; set; }
    }

    public class Karta
    {
        [Key]
        public int task_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime creation_date { get; set; }
        public string assigned_user { get; set; }
        public string Status { get; set; }
    }

    public class KanbanBoard
    {
        public List<Karta> Nowe { get; set; }
        public List<Karta> Zaplanowane { get; set; }
        public List<Karta> WTrakcie { get; set; }
        public List<Karta> Testowanie { get; set; }
        public List<Karta> Ukonczone { get; set; }
    }

    public class KanbanDbContext : DbContext
    {
        public DbSet<Karta> Zadania { get; set; }
        public DbSet<Uzytkownik> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = "server=127.0.0.1;database=kanbanboard;user=kanbanboard;password=admin1234";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
