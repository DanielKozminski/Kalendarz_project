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
    /// Logika interakcji dla klasy ManipulateProjectWindow.xaml
    /// </summary>
    public partial class ManipulateProjectWindow : Window
    {
        public bool Function = false;
        public string ShortDescription {  get; set; }
        public string LongDescription {  get; set; }
        public string ProjectName {  get; set; }

        public ManipulateProjectWindow(Project project)
        {
            InitializeComponent();
            if (project != null)
            {
                NameB.Text = project.Name;
                LDB.Text = project.LongDescription;
                SDB.Text = project.ShortDescription;
            }
        }
        private void Confirm_Click_Button(object sender, RoutedEventArgs e)
        {
            ShortDescription = SDB.Text;
            LongDescription = LDB.Text;
            ProjectName = NameB.Text;
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
