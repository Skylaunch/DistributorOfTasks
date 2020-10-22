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
using DistributorOfTasks.Pages.Employee;

namespace DistributorOfTasks.Windows
{
    /// <summary>
    /// Логика взаимодействия для StartEmployeeWindow.xaml
    /// </summary>
    public partial class StartEmployeeWindow : Window
    {
        public StartEmployeeWindow()
        {
            InitializeComponent();

            EmployeeFrame.Navigate(new TaskListPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
