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
using System.Xml.Linq;

namespace Kalendarz_project
{
    /// <summary>
    /// Logika interakcji dla klasy ManipulateTaskWindow.xaml
    /// </summary>
    public partial class ManipulateTaskWindow : Window
    {
        public ManipulateTaskWindow(Task task)
        {
            InitializeComponent();
            if (task != null)
            {
                NameB.Text = task.Name;
                DB.Text = task.Description;
            }
        }
        public bool Function = false;
        public string Description { get; set; }
        public string TaskName { get; set; }
        private void Confirm_Click_Button(object sender, RoutedEventArgs e)
        {
            Description = DB.Text;
            TaskName = NameB.Text;
            Function = true;

            this.Close();
        }
        private void Cancel_Click_Button(Object sender, RoutedEventArgs e)
        {
            Function = false;
            this.Close();
        }
    }
}
