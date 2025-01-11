using System.Windows;

namespace kanbanboard
{
    public partial class TaskDetailsWindow : Window
    {
        public TaskDetailsWindow(Karta selectedTask)
        {
            InitializeComponent();
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