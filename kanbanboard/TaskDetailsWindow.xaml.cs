using System.Windows;

namespace kanbanboard
{
    public partial class TaskDetailsWindow : Window
    {
        private readonly KanbanDbContext _dbContext;

        public TaskDetailsWindow(Karta selectedTask, KanbanDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
            DisplayTaskDetails(selectedTask);
        }


    private void DisplayTaskDetails(Karta task)
        {
            TaskTitleTextBlock.Text = task.title;
            AssignedUserTextBlock.Text = task.assigned_user;
            StatusTextBlock.Text = task.Status;
            TaskDescriptionTextBlock.Text = task.description;          
        }
    }
}