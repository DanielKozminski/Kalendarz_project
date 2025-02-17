using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz_project
{
    public class Task
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Task(string name,string desricption, string status) 
        {
            Name= name;
            Description= desricption;
            Status= status;
        }
        public void status_change()
        {
            return;
        }
    }
}
