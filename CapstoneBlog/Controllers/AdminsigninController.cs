using CapstoneBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneBlog.Controllers
{
    public class AdminsigninController : Controller
    {
        // GET: Adminsignin
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
            con.ConnectionString = "Server=tcp:capstoneapp.database.windows.net,1433;Initial Catalog=capstonedb;Persist Security Info=False;User ID=nehash;Password=Neha@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        }
        [HttpPost]
        public ActionResult Verify(AdminInfo adm)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from admininfo where EmailId='" + adm.EmailId + "' and Password='" + adm.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "employeeinfoes");
            }
            else
            {
                con.Close();
                return View();
            }



        }
    }
}