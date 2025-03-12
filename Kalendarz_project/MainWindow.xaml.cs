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

namespace Kalendarz_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProjectList.ListAdd(new Project("Project1", 1, "Krótki opis", "dłógi opis", "Planowany"));
            ProjectList.ListAdd(new Project("Project2", 2, "Krótki opis", "dłógi opis", "Planowany"));
            ProjectList.ListAdd(new Project("Project3", 3, "Krótki opis", "dłógi opis", "Planowany"));
            ProjectList.ListAdd(new Project("Project4", 3, "Krótki opis", "dłógi opis", "Planowany"));
            ProjectList.ListAdd(new Project("Project5", 3, "Krótki opis", "dłógi opis", "Planowany"));
            ProjectList.ListAdd(new Project("Project6", 3, "Krótki opis", "dłógi opis", "Planowany"));
            MainFrame.Navigate(new MainPage());
        }
        public void Main_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }
        public void Calendar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CalendarPage());
        }
        public void Project_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProjectPage());
        }
        public void Setting_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SettingPage());
        }
    }
}