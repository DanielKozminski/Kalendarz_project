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
        }
        private void BlockLoad()
        {
            foreach(Project project in ProjectList.AllProjects)
            {
                Border border = new Border();
                StackPanel block = new StackPanel();
                border.Height = 50;
                block.Width = border.Width;
                block.Height = border.Height;
                Label label = new Label();
                label.Height = 10;

                
            }
        }
    }
}
