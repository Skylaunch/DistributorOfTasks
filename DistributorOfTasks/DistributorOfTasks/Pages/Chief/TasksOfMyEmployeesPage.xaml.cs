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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DistributorOfTasks.Classes;

namespace DistributorOfTasks.Pages.Chief
{
    /// <summary>
    /// Логика взаимодействия для TasksOfMyEmployeesPage.xaml
    /// </summary>
    public partial class TasksOfMyEmployeesPage : Page
    {
        public List<TaskForUser> TaskList { get; set; }

        public TasksOfMyEmployeesPage()
        {
            InitializeComponent();
            DataContext = this;

            TaskList = Helper.Connection.TaskForUser.ToList().Where(t => t.User.Department.Id == Helper.CurrentUser.Department.Id).ToList();
            TasksOfMyEmployeesDataGrid.ItemsSource = TaskList;
        }
    }
}
