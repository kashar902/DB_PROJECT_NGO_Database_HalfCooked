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
    public class ProjectController : Controller
    {
        // *************************************  Prject Controller *************************************

        string connectionString = @"Data Source=DESKTOP-9928I97\MSSQLSERVER01;Initial Catalog=NGO;Integrated Security=True";
        private object productModel;


        // *************************************  Prject Index  *************************************

        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Project", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        // ************************************* INserting New Project  *************************************

        // GET: Project/Create
        public ActionResult Create()
        {
            return View(new ProjectModel());
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectModel projectModel)
        {
            // TODO: Add insert logic here
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "INSERT INTO Project VALUES(@ProName, @Start_date, @End_date)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ProName", projectModel.ProName);
                sqlCommand.Parameters.AddWithValue("@Start_date", projectModel.Start_date);
                sqlCommand.Parameters.AddWithValue("@End_date", projectModel.End_date);
                sqlCommand.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }


        // ************************************* Update A Project  *************************************

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            ProjectModel regModel = new ProjectModel();
            DataTable dataTableProduct = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "Select * from Project Where ID = @ID";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("ID", id);
                sqlDataAdapter.Fill(dataTableProduct);
            }
            if (dataTableProduct.Rows.Count == 1)
            {
                regModel.ID = Convert.ToInt32(dataTableProduct.Rows[0][0].ToString());
                regModel.ProName = dataTableProduct.Rows[0][1].ToString();
                regModel.Start_date = Convert.ToDateTime(dataTableProduct.Rows[0][2]);
                regModel.End_date = Convert.ToDateTime(dataTableProduct.Rows[0][3]);
                

                return View(regModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(ProjectModel projectModel  )
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "UPDATE Project SET ProName = @ProName, Start_date=@Start_date, End_date=@End_date Where ID = @ID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ID", projectModel.ID);
                sqlCommand.Parameters.AddWithValue("@ProName", projectModel.ProName);
                sqlCommand.Parameters.AddWithValue("@Start_date", projectModel.Start_date);
                sqlCommand.Parameters.AddWithValue("@End_date", projectModel.End_date);
                
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


        // ************************************* INserting New Project  *************************************

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {

            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Project WHERE ID = @ID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
