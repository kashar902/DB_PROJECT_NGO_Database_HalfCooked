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
    // ===================================  Volunteer  ================================================

    public class DefaultController : Controller
    {
        // GET: Default
        string connectionString = @"Data Source=DESKTOP-9928I97\MSSQLSERVER01;Initial Catalog=NGO;Integrated Security=True";

        // ===================================  Volunteer Index  ================================================

        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from Registration", sqlCon);
                sqlDa.Fill(dtblProduct);
            }
            return View(dtblProduct);
        }

        // ===================================  Add Volunteer  ================================================


        // GET: Default/Create
        public ActionResult Create()
        {
            return View(new registrationModel());
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(registrationModel regModel)
        {
            // TODO: Add insert logic here
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                //string querycity = "select * from Cities";
                string query = "INSERT INTO Registration VALUES(@FName, @LName, @Email, @PhoneNum,@Address, @City, @FWUKAU,@ShortIntro, @Gender)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@FName", regModel.FName);
                sqlCommand.Parameters.AddWithValue("@LName", regModel.LName);
                sqlCommand.Parameters.AddWithValue("@Email", regModel.Email);
                sqlCommand.Parameters.AddWithValue("@PhoneNum", regModel.PhNum);
                sqlCommand.Parameters.AddWithValue("@Address", regModel.Address);
                sqlCommand.Parameters.AddWithValue("@City", regModel.City);
                sqlCommand.Parameters.AddWithValue("@FWUKAU", regModel.FWUKAU);
                sqlCommand.Parameters.AddWithValue("@ShortIntro", regModel.ShortIntro);
                sqlCommand.Parameters.AddWithValue("@Gender", regModel.Gender);
                sqlCommand.ExecuteNonQuery();

            }
            return RedirectToAction("Index");

        }


        // ===================================  Update A Volunteer  ================================================

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            registrationModel regModel = new registrationModel();
            DataTable dataTableProduct = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "Select * from registration Where ID = @ID";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("ID", id);
                sqlDataAdapter.Fill(dataTableProduct);
            }
            if (dataTableProduct.Rows.Count == 1)
            {
                regModel.ID = Convert.ToInt32(dataTableProduct.Rows[0][0].ToString());
                regModel.FName = dataTableProduct.Rows[0][1].ToString();
                regModel.LName = dataTableProduct.Rows[0][2].ToString();
                regModel.Email = dataTableProduct.Rows[0][3].ToString();
                regModel.PhNum = dataTableProduct.Rows[0][4].ToString();
                regModel.Address = dataTableProduct.Rows[0][5].ToString();
                regModel.City = dataTableProduct.Rows[0][6].ToString();
                regModel.FWUKAU = dataTableProduct.Rows[0][7].ToString();
                regModel.ShortIntro = dataTableProduct.Rows[0][8].ToString();
                regModel.Gender = dataTableProduct.Rows[0][9].ToString();

                return View(regModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(registrationModel regModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string query = "UPDATE registration SET FName = @FName, LName=@LName, Email=@Email, PhNum=@PhNum, Address=@Address,City=@City,FWUKAU=@FWUKAU, ShortIntro=@ShortIntro, Genger=@Genger  Where ID = @ID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ID", regModel.ID);
                sqlCommand.Parameters.AddWithValue("@FName", regModel.FName);
                sqlCommand.Parameters.AddWithValue("@LName", regModel.LName);
                sqlCommand.Parameters.AddWithValue("@Email", regModel.Email);
                sqlCommand.Parameters.AddWithValue("@PhNum", regModel.PhNum);
                sqlCommand.Parameters.AddWithValue("@Address", regModel.Address);
                sqlCommand.Parameters.AddWithValue("@City", regModel.City);
                sqlCommand.Parameters.AddWithValue("@FWUKAU", regModel.FWUKAU);
                sqlCommand.Parameters.AddWithValue("@ShortIntro", regModel.ShortIntro);
                sqlCommand.Parameters.AddWithValue("@Genger", regModel.Gender);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // ===================================  Delete A Volunteer  ================================================


        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            DataTable dtblProduct = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM registration WHERE ID = @ID";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@ID", id);
                sqlCommand.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
        
            }
        }
