using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Kalendarz_project
{
    public class Project
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription {  get; set; }
        public string StatusName {  get; set; }
        public int StatusTag { get; set; }
        public ObservableCollection<Task> Tasks= new ObservableCollection<Task>();
        public Project(string name, string shortDescription, string longDescription, string status)
        {
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            status_change(0);
            ID= Setid();
        }
        private int Setid()
        {
            if(ProjectList.AllProjects.Count == 0)
            {
                ID = 1;
            }
            else
            {
                ID = ProjectList.AllProjects.Count()+1;
            }
            return ID; 
        }
        public void Add_Task(Task task)
        {
            Tasks.Add(task);
        }
        public void status_change(int tag)
        {
            StatusTag = tag;
            switch (StatusTag)
            {
                case 0:
                    StatusName = "Planowany";
                    break;
                case 1:
                    StatusName = "W trakcie";
                    break;
                case 2:
                    StatusName = "Wstrzymany";
                    break;
                case 3:
                    StatusName = "Zakończony";
                    break;
                default:
                    StatusName = "Planowany";
                    break;
            }
        }
    }
}
