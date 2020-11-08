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


namespace DistributorOfTasks.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для PublicTaskListPage.xaml
    /// </summary>
    public partial class PublicTaskListPage : Page
    {
        public List<PublicTask> PublicTaskList { get; set; }

        public PublicTaskListPage()
        {
            InitializeComponent();
            PublicTaskList = Helper.Connection.PublicTask.Where(t => t.DepartmentID == Helper.CurrentUser.DepartmentID).ToList();
            DataContext = this;
        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PublicTask selectedPublicTask = PublicTaskListDataGrid.SelectedItem as PublicTask;

                TaskForUser newTask = new TaskForUser
                {
                    Title = selectedPublicTask.Title,
                    Description = selectedPublicTask.Description,
                    PriorityID = selectedPublicTask.PriorityID,
                    Deadline = selectedPublicTask.Deadline,
                    UserID = Helper.CurrentUser.Id,
                    StatusID = 3
                };

                Helper.Connection.PublicTask.Remove(selectedPublicTask);
                Helper.Connection.TaskForUser.Add(newTask);
                Helper.Connection.SaveChanges();

                PublicTaskListPage publicTasks = new PublicTaskListPage();
                NavigationService.Navigate(publicTasks);

                MessageBox.Show("Success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
