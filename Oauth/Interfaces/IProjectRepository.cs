using Oauth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oauth.Interfaces
{
    interface IProjectRepository
    {
        Project GetProjectById(int id);
        //display
        IEnumerable<Project> getdata();
        //insert
        void Addnewrecord(Project project);//project data goes from view model

        //update
        void EditRecord(Project project);

        //delete
        void Delete(int id);
        //search

        void Save();
    }
}