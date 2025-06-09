using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Kalendarz_project
{
    public class Task 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusName { get; set; }
        public int StatusTag { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public Task(string name,string desricption) 
        {
            Name= name;
            Description= desricption;
            StatusName= "git";
            status_change(0);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void status_change(int tag)
        {
            StatusTag= tag;
            switch(StatusTag)
            {
                case 0:
                    StatusName = "Planowany";
                    break;
                case 1:
                    StatusName= "W trakcie";
                    break;
                case 2:
                    StatusName= "Wstrzymany";
                    break;
                case 3:
                    StatusName= "Zakończony";
                    break;
                default:
                    StatusName = "Planowany";
                    break;
            }
        }
        public SolidColorBrush ColourName()
        {
            SolidColorBrush colour;
            switch (this.StatusTag)
            {
                case 0:
                    colour = new SolidColorBrush(Colors.Yellow);
                    break;
                case 1:
                    colour = new SolidColorBrush(Colors.Green);
                    break;
                case 2:
                    colour = new SolidColorBrush(Colors.Red);
                    break;
                case 3:
                    colour = new SolidColorBrush(Colors.Blue);
                    break;
                default:
                    colour = new SolidColorBrush(Colors.Yellow);
                    break;
            }
            return colour;
        }
    }
}
