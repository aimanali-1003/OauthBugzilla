using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Oauth.Models;
using Oauth.Repository;

namespace Oauth.Controllers
{
    
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ProjectRepository pr = new ProjectRepository();
        public ActionResult Index()
        {
            return View(pr.getdata());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(pr.search(id));
        }


        [Authorize (Roles = "Manager")]
        // GET: Projects/Create
        public ActionResult Create()
        {
            Project s = new Project();
            return View(s);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public ActionResult Create(Project project)
        {
            try
            {
                // TODO: Add insert logic here
                pr.Addnewrecord(project);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            var objemp = pr.GetProjectById(id);
            return View(objemp);

        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Project project)
        {
            try
            {
                pr.EditRecord(project);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            var project = pr.GetProjectById(id);
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            pr.Delete(id);
            pr.Save();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pr.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
