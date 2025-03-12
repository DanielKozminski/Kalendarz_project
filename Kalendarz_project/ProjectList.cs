using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz_project
{
    public static class ProjectList
    {
        public static ObservableCollection<Project> AllProjects= new ObservableCollection<Project>();
        public static void ListAdd(Project project)
        {
            AllProjects.Add(project);
        }
    }
}
