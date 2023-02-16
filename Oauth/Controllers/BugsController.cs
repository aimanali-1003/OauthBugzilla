using System.Linq;
using System.Net;
using System.Web.Mvc;
using Oauth.Interfaces;
using Oauth.Models;
using Oauth.Repository;

namespace Oauth.Controllers
{
    public class BugsController : Controller
    {
        private readonly BugRepository _repository = new BugRepository();

        public ActionResult Index()
        {
            var bugs = _repository.GetData();
            return View(bugs);
        }

        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bug = _repository.Search(id);
            return View(bug);
        }

        public ActionResult Create()
        {
            ViewBag.UserNames = _repository.GetUserNames();
            ViewBag.ProjectNames = _repository.GetProjectNames();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bug bug)
        {
            if (ModelState.IsValid)
            {
                _repository.AddNewRecord(bug);
                _repository.Save();

                return RedirectToAction("Index");
            }
            return View(bug);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = _repository.GetBugById(id);
            if (bug == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserNames = _repository.GetUserNames();
            ViewBag.ProjectNames = _repository.GetProjectNames();

            return View(bug);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Bug bug)
        {
            if (ModelState.IsValid)
            {
                _repository.EditRecord(bug);
                return RedirectToAction("Index");
            }

            ViewBag.UserNames = _repository.GetUserNames();
            ViewBag.ProjectNames = _repository.GetProjectNames();
            return View(bug);
        }

        public ActionResult Delete(int id)
        {
            var bug = _repository.GetBugById(id);
            return View(bug);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
