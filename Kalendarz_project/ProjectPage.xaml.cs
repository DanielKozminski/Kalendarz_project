using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Kalendarz_project
{
    /// <summary>
    /// Logika interakcji dla klasy ProjectPage.xaml
    /// </summary>
    public partial class ProjectPage : Page
    {
        public ProjectPage()
        {
            InitializeComponent();
            BlockLoad();
        }
        private void BlockLoad()
        {
            foreach(Project project in ProjectList.AllProjects)
            {
                Border border = new Border();
                StackPanel block = new StackPanel();
                border.Style = (Style)FindResource("Borders");
                border.Height = 100;
                block.Width = border.Width;
                block.Height = 100;
                Label Namelabel = new Label();
                Label ShortDescription = new Label();
                Label Status = new Label();
                Button open = new Button();
                Namelabel.Content = "Nazwa: "+project.Name;
                ShortDescription.Content = "Opis: " + project.ShortDescription;
                Status.Content = "Status: "+ project.StatusName;
                open.Content = "Otwórz";
                open.Click += Open_Project_Click;
                open.Tag = project;
                open.Height = 20;
                block.Children.Add(Namelabel);
                block.Children.Add(ShortDescription);
                block.Children.Add(Status);
                block.Children.Add(open);
                border.Child = block;
                LeftPanel.Children.Add(border);
            }
        }
        private void Open_Project_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if(clickedButton?.Tag is Project project)
            {
                StatusTextBlock.Text = "Status: " + project.StatusName;
                NameTextBlock.Text = "Nazwa Projektu:\n"+project.Name;
                LDTextBlock.Text = project.LongDescription;
                StatusChangeButton.Tag = clickedButton.Tag;
                NewTaskButton.Tag = clickedButton.Tag;
            }      
        }
        private void New_Project_Click(object sender, RoutedEventArgs e)
        {

            ProjectList.ListAdd(new Project("Added class","Created class", "new created class","Planowany"));
            Project project = ProjectList.AllProjects[ProjectList.AllProjects.Count-1];
            Border border = new Border();
            StackPanel block = new StackPanel();
            border.Style = (Style)FindResource("Borders");
            border.Height = 100;
            block.Width = border.Width;
            block.Height = 100;
            Label Namelabel = new Label();
            Label ShortDescription = new Label();
            Label Status = new Label();
            Button open = new Button();
            Namelabel.Content = "Nazwa: " + project.Name;
            ShortDescription.Content = "Opis: " + project.ShortDescription;
            Status.Content = "Status: " + project.StatusName;
            open.Content = "Otwórz";
            open.Click += Open_Project_Click;
            open.Tag = project;
            open.Height = 20;
            block.Children.Add(Namelabel);
            block.Children.Add(ShortDescription);
            block.Children.Add(Status);
            block.Children.Add(open);
            border.Child = block;
            LeftPanel.Children.Add(border);
        }
        private void Status_Change_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            StatusChangeWindow statusChangeWindow = new StatusChangeWindow();
            statusChangeWindow.ShowDialog();
            if(button?.Tag is Project project)
            {
                if (statusChangeWindow.status != 0)
                {
                    project.status_change(statusChangeWindow.status);
                    StatusTextBlock.Text = "Status: " + project.StatusName;
                    LeftPanel.Children.Clear();
                    BlockLoad();
                }
            }
        }
        private void NewTask_Click(object sender, EventArgs e)
        {

        }
        private void OpenTask_Click(object sender, EventArgs e)
        {

        }
        private void Edit_Project_Click(object sender, EventArgs e)
        {

        }
        private void Delete_Project_Click(Object sender, EventArgs e)
        {

        }
        private void Task_Load()
        {

        }

    }
}
