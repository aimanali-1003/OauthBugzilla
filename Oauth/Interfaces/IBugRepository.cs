using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Oauth.Interfaces
{
    public interface IBugRepository
    {
        Bug GetBugById(int id);
        //display
        IEnumerable<Bug> GetData();
        //insert
        void AddNewRecord(Bug bug);//project data goes from view model

        //update
        void EditRecord(Bug bug);

        //delete
        void Delete(int id);
        //search

       IEnumerable<SelectListItem> GetUserNames();

        IEnumerable<SelectListItem> GetProjectNames();

        void Save();
        void Dispose();
    }
}