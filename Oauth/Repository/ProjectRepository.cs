using Oauth.Interfaces;
using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Oauth.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        DB db = new DB();
        private bool disposed = false;
        public void Addnewrecord(Project project)
        {
            Project p = new Project();
            p.Title = project.Title;
            p.Description = project.Description;
            db.Projects.Add(p);
            db.SaveChanges();
        }

        public void EditRecord(Project project)
        {
            db.Entry(project).State = EntityState.Modified;
            Project s = db.Projects.Where(x => x.ProjectId == project.ProjectId).FirstOrDefault();
            s.Title = project.Title;
            s.Description = project.Description;
            db.SaveChanges();
        }

        public IEnumerable<Project> getdata()
        {
            return db.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return db.Projects.Find(id);
        }

        public Project search(int id)
        {
            Project s = new Project();
            Project se = db.Projects.Where(x => x.ProjectId == id).SingleOrDefault();
            s.ProjectId = se.ProjectId;
            s.Title = se.Title;
            s.Description = se.Description;

            return s;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Delete(int id)
        {
            var product = db.Projects.Find(id);
            db.Projects.Remove(product);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
