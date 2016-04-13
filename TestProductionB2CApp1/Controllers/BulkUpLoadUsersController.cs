using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProductionB2CApp1.Models;

namespace TestProductionB2CApp1.Controllers
{
    public class BulkUpLoadUsersController : Controller
    {
        // GET: BulkUpLoadUsers
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload, BulkUpload model)
        {
            string info = "";
            try {
                // Check if the user has entered application ids
                if (model.Applications.Trim().Length > 0)
                {
                    string[] appications = model.Applications.Split(';');

                    string[] securityRoles = model.SecurityRoles.Split(';');

                    string[] permissionGroups = model.PermissionGroups.Split(';');

                    var file = new System.IO.StreamReader(upload.InputStream);

                    while (file.Peek() >= 0)
                    {
                        string line = file.ReadLine();

                        string[] fields = line.Split(',');

                        var bulkUser = new BulkUser();

                        bulkUser.Title = fields[0];
                        bulkUser.GivenName = fields[1];
                        bulkUser.MiddleName = fields[2];
                        bulkUser.Surname = fields[3];
                        bulkUser.Email = fields[4];
                        bulkUser.Password = fields[5];

                        // call to creat user

                    // call 

                    }
                }
                else
                {
                    // No Application entered
                    info = "No Application Ids entered.";
                }
            }
            catch (Exception exp)
            {
                info = exp.Message;
            }

            return View();
        }
    }
}