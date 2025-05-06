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

namespace Kalendarz_project
{
    /// <summary>
    /// Logika interakcji dla klasy StatusChange.xaml
    /// </summary>
    public partial class StatusChangeWindow : Window
    {
        public int status = 0;
        public StatusChangeWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Finish_Click(object sender, RoutedEventArgs e)
        {
            status = 3;
            this.Close();
        }
        private void Button_Paused_Click(object sender, RoutedEventArgs e)
        {
            status = 2;
            this.Close();
        }
        private void Button_Active_Click(object sender, RoutedEventArgs e)
        {
            status = 1;
            this.Close();
        }
        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            status = 0;
            this.Close();
        }
    }
}
