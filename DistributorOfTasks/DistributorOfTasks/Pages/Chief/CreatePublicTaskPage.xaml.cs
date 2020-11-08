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
    /// Логика взаимодействия для CreatePublicTaskPage.xaml
    /// </summary>
    public partial class CreatePublicTaskPage : Page
    {
        private List<string> PriorityList { get; set; } = Helper.Connection.Priority.Select(p => p.Title).ToList();
        private List<string> DepartamentList { get; set; } = Helper.Connection.Department.Select(p => p.Title).ToList();

        public CreatePublicTaskPage()
        {
            InitializeComponent();
            PriorityComboBox.ItemsSource = PriorityList;
            DepartmentComboBox.ItemsSource = DepartamentList;
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
                    return;
                }
                PublicTask newTask = new PublicTask
                {
                    Title = TitleTextBox.Text,
                    Description = DescriptionTextBox.Text,
                    Deadline = DeadlineDatePicker.DisplayDate,
                    PriorityID = Helper.Connection.Priority.Where(p => p.Title == PriorityComboBox.SelectedValue.ToString()).First().Id,
                    DepartmentID = Helper.Connection.Department.Where(d => d.Title == DepartmentComboBox.SelectedValue.ToString()).First().Id
                };

                Helper.Connection.PublicTask.Add(newTask);
                Helper.Connection.SaveChanges();

                MessageBox.Show("Success");
                RefreshFields();
            }
            catch (Exception exception)
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
            DepartmentComboBox.SelectedIndex = 0;
        }
    }
}