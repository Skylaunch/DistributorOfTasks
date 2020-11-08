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
using DistributorOfTasks.Pages.Chief;

namespace DistributorOfTasks.Windows
{
    /// <summary>
    /// Логика взаимодействия для StartChiefWindow.xaml
    /// </summary>
    public partial class StartChiefWindow : Window
    {
        //TODO: Create dependency  of the label on the form you are on

        public StartChiefWindow()
        {
            InitializeComponent();

            ChiefFrame.Navigate(new TasksOfMyEmployeesPage());
        }

        private void CheckingButton_Click(object sender, RoutedEventArgs e)
        {
            ChiefFrame.Navigate(new TasksOfMyEmployeesPage());
        }

        private void CreateTaskForUserButton_Click(object sender, RoutedEventArgs e)
        {
            ChiefFrame.Navigate(new CreateTaskForUserPage());
        }

        private void CreatePublicTaskButton_Click(object sender, RoutedEventArgs e)
        {

            ChiefFrame.Navigate(new CreatePublicTaskPage());
        }
    }
}
