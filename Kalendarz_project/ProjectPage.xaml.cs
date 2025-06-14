﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        Project SelectedProject = new Project("", "", "");
        public ProjectPage()
        {
            InitializeComponent();
            BlockLoad();
            Project_Base_Select();
        }
        private void BlockLoad()
        {
            if (ProjectList.AllProjects.Count > 0)
            {
                LeftPanel.Children.Clear();
                foreach (Project project in ProjectList.AllProjects)
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
                    Namelabel.Content = "Nazwa: " + project.Name;
                    ShortDescription.Content = "Opis: " + project.ShortDescription;
                    Status.Content = "Status: " + project.StatusName;
                    Status.Foreground = project.ColourName();
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
        }
        private void Open_Project_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if(clickedButton?.Tag is Project project)
            {
                StatusTextBlock.Text = "Status: " + project.StatusName;
                StatusTextBlock.Foreground = project.ColourName();
                NameTextBlock.Text = "Nazwa Projektu:\n"+project.Name;
                LDTextBlock.Text = project.LongDescription;
                StatusChangeButton.Tag = clickedButton.Tag;
                NewTaskButton.Tag = clickedButton.Tag;
                EditButton.Tag = clickedButton.Tag;
                DeleteButton.Tag = clickedButton.Tag;
                SelectedProject = project;
            }      
        }
        private void New_Project_Click(object sender, RoutedEventArgs e)
        {
            ManipulateProjectWindow pwindow = new ManipulateProjectWindow(null);
            pwindow.ShowDialog();
            if (pwindow.Function == true)
            {
                ProjectList.ListAdd(new Project(pwindow.ProjectName, pwindow.ShortDescription, pwindow.LongDescription));
                Project project = ProjectList.AllProjects[ProjectList.AllProjects.Count - 1];
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
                Status.Foreground = project.ColourName();
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
        private void StatusProject_Change_Click(object sender, EventArgs e)
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
                    StatusTextBlock.Foreground = project.ColourName();
                    BlockLoad();
                }
            }
        }
        private void StatusTask_Change_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            StatusChangeWindow statusChangeWindow = new StatusChangeWindow();
            statusChangeWindow.ShowDialog();
            if (button?.Tag is Task task)
            {
                if (statusChangeWindow.status != 0)
                {
                    task.status_change(statusChangeWindow.status);
                    StatusTextBlock.Text = "Status: " + task.StatusName; // Do zmiany
                    StatusTextBlock.Foreground = task.ColourName(); //Do zmiany
                    Task_Load(SelectedProject);
                }
            }
        }
        private void NewTask_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton?.Tag is Project project)
            {
                ManipulateTaskWindow twindow = new ManipulateTaskWindow(null);
                twindow.ShowDialog();
                if(twindow.Function == true)
                {
                    project.Add_Task(new Task(twindow.TaskName, twindow.Description));
                    Task task = project.Tasks[project.Tasks.Count - 1];
                    Border border = new Border();
                    StackPanel block = new StackPanel();
                    border.Style = (Style)FindResource("Borders");
                    border.Height = 70;
                    block.Width = border.Width;
                    block.Height = 70;
                    Label Namelabel = new Label();
                    Label Status = new Label();
                    Button open = new Button();
                    Namelabel.Content = "Nazwa: " + task.Name;
                    Status.Content = "Status: " + task.StatusName;
                    Status.Foreground = task.ColourName();
                    open.Content = "Otwórz";
                    open.Click += OpenTask_Click;
                    open.Tag = task;
                    open.Height = 20;
                    block.Children.Add(Namelabel);
                    block.Children.Add(Status);
                    block.Children.Add(open);
                    border.Child = block;
                    TaskPanel.Children.Add(border);
                }
                
            }
            
        }
        private void OpenTask_Click(object sender, EventArgs e)
        {

        }
        private void Edit_Project_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton?.Tag is Project project)
            {
                    ManipulateProjectWindow pwindow = new ManipulateProjectWindow(project);
                pwindow.ShowDialog();
                if (pwindow.Function == true)
                {
                    project.Name = pwindow.ProjectName;
                    project.ShortDescription= pwindow.ShortDescription;
                    project.LongDescription= pwindow.LongDescription;
                    StatusTextBlock.Text = "Status: " + project.StatusName;
                    StatusTextBlock.Foreground = project.ColourName();
                    NameTextBlock.Text = "Nazwa Projektu:\n" + project.Name;
                    LDTextBlock.Text = project.LongDescription;
                    StatusChangeButton.Tag = clickedButton.Tag;
                    NewTaskButton.Tag = clickedButton.Tag;
                    EditButton.Tag = clickedButton.Tag;
                    DeleteButton.Tag = clickedButton.Tag;
                }
                BlockLoad();
            }
        }
        private void Delete_Project_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Czy na pewno chcesz kontynuować?",
            "Potwierdzenie",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Button clickedButton = sender as Button;
                if (clickedButton?.Tag is Project project)
                {
                    ProjectList.ListRemove(project);
                    project= null;
                    BlockLoad();
                    Project_Base_Select();
                }
            }
        }
        private void Task_Load(Project project)
        {
            if(project.Tasks.Count > 0)
            {
                TaskPanel.Children.Clear();
                foreach (Task task in project.Tasks)
                {
                    Border border = new Border();
                    StackPanel block = new StackPanel();
                    border.Style = (Style)FindResource("Borders");
                    border.Height = 70;
                    block.Width = border.Width;
                    block.Height = 70;
                    Label Namelabel = new Label();
                    Label Status = new Label();
                    Button open = new Button();
                    Namelabel.Content = "Nazwa: " + task.Name;
                    Status.Content = "Status: " + task.StatusName;
                    Status.Foreground = task.ColourName();
                    open.Content = "Otwórz";
                    open.Click += OpenTask_Click;
                    open.Tag = task;
                    open.Height = 20;
                    block.Children.Add(Namelabel);
                    block.Children.Add(Status);
                    block.Children.Add(open);
                    border.Child = block;
                    TaskPanel.Children.Add(border);
                }
            }
            
        }
        private void Project_Base_Select()
        {
            if(ProjectList.AllProjects.Count > 0)
            {
                Project project = ProjectList.AllProjects.First();
                StatusTextBlock.Text = "Status: " + project.StatusName;
                StatusTextBlock.Foreground = project.ColourName();
                NameTextBlock.Text = "Nazwa Projektu:\n" + project.Name;
                LDTextBlock.Text = project.LongDescription;
                StatusChangeButton.Tag = project;
                NewTaskButton.Tag = project;
                EditButton.Tag = project;
                DeleteButton.Tag = project;
            }   
        }
    }
}
