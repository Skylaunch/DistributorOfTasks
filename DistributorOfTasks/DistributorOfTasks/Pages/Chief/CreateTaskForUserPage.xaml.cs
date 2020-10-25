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
    /// Логика взаимодействия для CreateTaskForUserPage.xaml
    /// </summary>
    public partial class CreateTaskForUserPage : Page
    {
        private List<string> UsersList { get; set; } = Helper.Connection.User.
            Where(u => u.Department.Id == Helper.CurrentUser.Department.Id).Select(u => "№"+ u.Id +" "+ u.Surname +" " + u.Name).ToList();

        private List<string> PriorityList { get; set; } = Helper.Connection.Priority.Select(p => p.Title).ToList();

        public CreateTaskForUserPage()
        {
            InitializeComponent();
            PriorityComboBox.ItemsSource = PriorityList;
            UserComboBox.ItemsSource = UsersList;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(TitleTextBox.Text) || String.IsNullOrEmpty(DescriptionTextBox.Text) || String.IsNullOrEmpty(DeadlineDatePicker.Text))
                {
                    MessageBox.Show("You must filling all fields");
                    return;
                }
                else if (DateTime.Now > DeadlineDatePicker.SelectedDate)
                {
                    MessageBox.Show("Deadline can't be earlier than today");
                    MessageBox.Show(DeadlineDatePicker.SelectedDate.ToString());
                    MessageBox.Show(DateTime.Now.ToString());
                    return;
                }
                TaskForUser newTask = new TaskForUser();
                newTask.Title = TitleTextBox.Text;
                newTask.Description = DescriptionTextBox.Text;
                newTask.Deadline = DeadlineDatePicker.DisplayDate;
                newTask.PriorityID = Helper.Connection.Priority.Where(p => p.Title == PriorityComboBox.SelectedValue.ToString()).First().Id;
                newTask.StatusID = Helper.Connection.Status.Where(s => s.Title == "In process").First().Id;

                //Search correct User
                string selectedUser = UserComboBox.SelectedItem as string;
                selectedUser = selectedUser.Remove(selectedUser.IndexOf(" "));
                selectedUser = selectedUser.Remove(0, 1);
                int correctUserId = Convert.ToInt32(selectedUser);
                newTask.UserID = correctUserId;

                Helper.Connection.TaskForUser.Add(newTask);
                Helper.Connection.SaveChanges();

                MessageBox.Show("Success");
                RefreshFields();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void RefreshFields()
        {
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
            DeadlineDatePicker.Text = "";
            PriorityComboBox.SelectedIndex = 0;
            UserComboBox.SelectedIndex = 0;
        }
    }
}
