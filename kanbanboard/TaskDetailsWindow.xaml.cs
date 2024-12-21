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
            TaskDescriptionTextBlock.Text = task.description;
            AssignedUserTextBlock.Text = task.assigned_user;
            StatusTextBlock.Text = task.Status;
        }
    }
}