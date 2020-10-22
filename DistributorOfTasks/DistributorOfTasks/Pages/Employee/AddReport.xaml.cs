using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;

using Word = Microsoft.Office.Interop.Word;
using System.Windows.Threading;

namespace DistributorOfTasks.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для AddReport.xaml
    /// </summary>
    public partial class AddReport : System.Windows.Controls.Page
    {
        private TaskForUser CurrentTask { get; set; }
        private Word.Application app = new Word.Application();
        private string reportText;

        public AddReport(TaskForUser task)
        {
            InitializeComponent();
            CurrentTask = task;
        }

        private async void CreateReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reportText = ReportTextBlock.Text;

                await System.Threading.Tasks.Task.Run(() =>
                {
                    string reportDir = Environment.CurrentDirectory + @"\..\..\Reports\";
                    Document doc = GetDoc(reportDir + "Template.docx");
                    doc.SaveAs(reportDir + $"Task №{CurrentTask.Id}.docx");
                    doc.Close();
                    MessageBox.Show("Report was added");
                });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Document GetDoc(string path)
        {
            Document newDoc = app.Documents.Add(path);
            SetTemplate(newDoc);
            return newDoc;
        }
            
        private void SetTemplate(Document newDoc)
        {
            foreach (Bookmark b in newDoc.Bookmarks)
            {
                b.Range.Bold = 20;
            }
            newDoc.Bookmarks["taskTitle"].Range.Text = CurrentTask.Title;
            newDoc.Bookmarks["status"].Range.Text = CurrentTask.StatusID == 2 ? "Fail" : "Success";
            newDoc.Bookmarks["description"].Range.Text = CurrentTask.Description;
            newDoc.Bookmarks["user"].Range.Text = $"{CurrentTask.User.Surname} {CurrentTask.User.Name}";
            newDoc.Bookmarks["report"].Range.Text = reportText;
        }

        private void DownloadReportButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("In the development");
        }
    }
}