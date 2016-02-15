using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using System.Data;

namespace TestAccessDBWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetDataFromAccess()
        {
            OleDbConnection connection = new OleDbConnection();
            OleDbCommand command = new OleDbCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet dataset = new DataSet();

            string path = Server.MapPath("/");


            connection.ConnectionString =
                @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "PBSGL-DB_BaclEnd_MDB_Version.MDB;" +
                "Persist Security Info=False";



            command.Connection = connection;
            command.CommandText = "SELECT * FROM Members";

            adapter.SelectCommand = command;

            string s = "";
            try
            {

                ViewData["ConnectionString"] = connection.ConnectionString;


                adapter.Fill(dataset, "Members");

                s = Convert.ToString(dataset.Tables["Members"].Rows[1][8]);





            }
            catch (OleDbException e)
            {
                ViewData["ErrorMsg"] = e.Message;
                //Console.WriteLine(e.Message);
                //  MessageBox.Show("Error occured while connecting to database.");
                // Application.Exit();
            }
            finally
            {
                connection.Close();
            }

           ViewData["AccessData"] = s;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}