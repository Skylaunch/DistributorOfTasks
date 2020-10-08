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

namespace DistributorOfTasks
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            UserList = Helper.Connection.User.ToList();
        }

        public List<User> UserList { get; set; }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if(String.IsNullOrWhiteSpace(LoginTextBox.Text) || String.IsNullOrWhiteSpace(Password.Password))
            {
                MessageBox.Show("Must be completed all fields");
                return;
            }
            foreach (User u in UserList)
            {
                if(u.Login == LoginTextBox.Text && u.Password == Password.Password)
                {
                    Helper.CurrentUser = u;
                    MessageBox.Show("Success"); //DELETE THAT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    if(Helper.CurrentUser.Role.Title == "Employee")
                    {
                        //Employee
                    }
                    else
                    {
                        //Boss
                    }

                    return;
                }
            }
            MessageBox.Show("This user was not found :(", "Authorization error");
        }
    }
}
