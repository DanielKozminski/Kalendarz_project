using Microsoft.EntityFrameworkCore;
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
            using var db = new AppDbContext();
            db.Projects.Add(project);
            db.SaveChanges();
        }
        public static void ListRemove(Project project)
        {
            using var db = new AppDbContext();
            var toRemove = db.Projects.Include(p => p.Tasks).FirstOrDefault(p => p.ID == project.ID);
            if (toRemove != null)
            {
                db.Projects.Remove(toRemove);
                db.SaveChanges();
                AllProjects.Remove(project);
            }
        }
        public static void UpdateProject(Project updatedProject)
        {
            using var db = new AppDbContext();
            db.Projects.Update(updatedProject);
            db.SaveChanges();
        }
        public static void LoadFromDatabase()
        {
            using var db = new AppDbContext();
            var projects = db.Projects.Include(p => p.Tasks).ToList();
            AllProjects = new ObservableCollection<Project>(projects);
        }
    }
}
