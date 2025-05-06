using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz_project
{
    public class Task : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusName {  get; set; }
        public int StatusTag { get; set; }
        public Task(string name,string desricption) 
        {
            Name= name;
            Description= desricption;
            StatusTag= 0;
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
    }
}
