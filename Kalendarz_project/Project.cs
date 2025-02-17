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
        public string Description { get; set; }
        public string Status { get; set; }
        public ObservableCollection<Task> Tasks { get; set; }
        public void Add_Task(Task task)
        {
            Tasks.Add(task);
        }
    }
}
