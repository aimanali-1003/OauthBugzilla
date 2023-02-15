using Oauth.Interfaces;
using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Oauth.Repository
{
    public class BugRepository : IBugRepository
    {
        DB db = new DB();
        private bool disposed = false;
        public void AddNewRecord(Bug bug)
        {
            Bug b = new Bug();
            b.title = bug.title;
            b.status = b.status;
            b.type= bug.type;
            b.deadline= bug.deadline;
            b.UserId = bug.UserId;
            b.ProjectId = bug.ProjectId;
            db.Bugs.Add(b);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var bug = db.Bugs.Find(id);
            if (bug != null) db.Bugs.Remove(bug);
        }

        public void EditRecord(Bug bug)
        {
            db.Entry(bug).State = EntityState.Modified;
            Bug b = db.Bugs.Where(x => x.BugId == bug.BugId).FirstOrDefault();
            b.title = bug.title;
            b.status = b.status;
            b.type = bug.type;
            b.deadline = bug.deadline;
            b.UserId = bug.UserId;
            b.ProjectId = bug.ProjectId;
            db.SaveChanges();
        }

        public Bug GetBugById(int id)
        {
            return db.Bugs.Find(id);
        }

        public IEnumerable<Bug> GetData()
        {
            return db.Bugs.ToList();
        }

        public IEnumerable<SelectListItem> GetUserNames()
        {
            var users = db.Users
                .Select(u => new SelectListItem { Value = u.UserId.ToString(), Text = u.Name })
                .ToList();
            return users;
        }

        public IEnumerable<SelectListItem> GetProjectNames()
        {
            var projects = db.Projects
                .Select(u => new SelectListItem { Value = u.ProjectId.ToString(), Text = u.Title })
                .ToList();
            return projects;
        }

        //public User GetUserById(int id)
        //{
        //    return db.Users.FirstOrDefault(u => u.UserId == id);
        //}
        //public List<string> GetUserNames()
        //{
        //    var userNames = db.Users.Select(u => u.Name).ToList();
        //    return userNames;
        //}

        //public List<string> GetUserNamesByIds(List<int> userIds)
        //{
        //    return db.Users
        //        .Where(u => userIds.Contains(u.UserId))
        //        .Select(u => u.Name)
        //        .ToList();
        //}

        //public IEnumerable<User> GetUsers()
        //{
        //    return db.Users.ToList();
        //}

        public List<int> GetProjectIds()
        {
            return db.Projects.Select(u => u.ProjectId).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Bug Search(int id)
        {
            Bug s = new Bug();
            Bug se = db.Bugs.Where(x => x.BugId == id).SingleOrDefault();
            s.BugId = se.BugId;
            s.title = se.title;
            s.status = se.status;
            s.type = se.type;
            s.deadline = se.deadline;
            s.UserId = se.UserId;
            s.ProjectId = se.ProjectId;

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
    }
}