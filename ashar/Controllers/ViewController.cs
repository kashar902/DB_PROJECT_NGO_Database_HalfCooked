using ashar.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ashar.Controllers
{
    public class ViewController : Controller
    {
        string connectionString = @"Data Source=DESKTOP-9928I97\MSSQLSERVER01;Initial Catalog=NGO;Integrated Security=True";

        // *************************************  Volunteers Profile  *************************************

        // GET: View

        public ActionResult Profile()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Volunteers_Profile", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }


        // ************************************* Volunteers Profile With Project  *************************************

        public ActionResult Proj_participation()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(" select * from Vol_Proj_participation", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        // ************************************* Individual Volunteer Profile  *************************************


    }
}