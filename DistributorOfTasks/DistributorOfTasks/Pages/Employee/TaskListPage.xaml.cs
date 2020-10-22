using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace DistributorOfTasks.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для TaskListPage.xaml
    /// </summary>
    public partial class TaskListPage : Page
    {
        public List<TaskForUser> TaskList { get; set; }

        public TaskListPage()
        {
            InitializeComponent();
            DataContext = this;
            TaskList = Helper.Connection.TaskForUser.ToList().Where(t => t.UserID == Helper.CurrentUser.Id).ToList();

        }

        private void SuccessButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshStatusAndTable(1);
        }

        private void FailedButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshStatusAndTable(2);
        }

        private void RefreshStatusAndTable(int newStatusID)
        {

            TaskForUser SelectedTask = (TaskListDataGrid.SelectedItem as TaskForUser);
            if (SelectedTask.StatusID == 3)
            {
                SelectedTask.StatusID = newStatusID;
                Helper.Connection.SaveChanges();

                DataContext = null;
                DataContext = this;

                if (newStatusID == 1) //Success
                {
                    MessageBoxResult myResult = MessageBox.Show("Want you add report about this task?", "Report", MessageBoxButton.YesNo);
                    if (myResult == MessageBoxResult.Yes)
                        NavigationService.Navigate(new AddReport(SelectedTask));
                }
                else if (newStatusID == 2) //Fail
                {
                    MessageBox.Show("You must write report about this task");
                    NavigationService.Navigate(new AddReport(SelectedTask));
                }
            }
        }

    }
}
