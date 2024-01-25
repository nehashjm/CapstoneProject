using CapstoneBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneBlog.Controllers
{
    public class EmployeeSigninController : Controller
    {
        // GET: EmployeeSignin
        // GET: AdminSignIn
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: EmpSignin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {
            con.ConnectionString = "Server=tcp:capstoneapp.database.windows.net,1433;Initial Catalog=capstonedb;Persist Security Info=False;User ID=nehash;Password=Neha@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";

        }
        [HttpPost]
        public ActionResult Verify(employeeinfo emp)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from employeeinfo where emailid='" + emp.emailid + "' and passcode='" + emp.passcode + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "BlogInfoes");
            }
            else
            {
                con.Close();
                return View();
            }



        }
    }
}