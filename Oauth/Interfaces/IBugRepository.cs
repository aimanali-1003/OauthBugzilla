using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        void Save();
    }
}