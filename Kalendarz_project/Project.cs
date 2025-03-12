using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz_project
{
    public class Project
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription {  get; set; }
        public string Status { get; set; }
        public ObservableCollection<Task> Tasks= new ObservableCollection<Task>();
        public Project(string name,int iD, string shortDescription, string longDescription, string status)
        {
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            Status = status;
            ID= iD;
        }

        public void Add_Task(Task task)
        {
            Tasks.Add(task);
        }
    }
}
