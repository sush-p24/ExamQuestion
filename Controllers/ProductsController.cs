using ExamQuestion.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamQuestion.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "FetchProducts";

            List<Product> prod = new List<Product>();

            try
            {
                SqlDataReader sd = cmd.ExecuteReader();
                while (sd.Read())
                {
                    prod.Add(new Product { ProductId = (int)sd["ProductId"], ProductName = sd["ProductName"].ToString(), Rate = (decimal)sd["Rate"], Description = sd["Description"].ToString(), CategoryName = sd["CategoryName"].ToString() });


                }
            }
            catch (Exception e)
            {
                ViewBag.err = e.Message;
            }
            finally { con.Close(); }
           
            
            
            return View(prod);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id=0)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetProduct";
            cmd.Parameters.AddWithValue("@ProductId", id);
            SqlDataReader sd = cmd.ExecuteReader();
            Product pr = new Product();
            if(sd.Read())
            {
                pr = new Product { ProductId = (int)sd["ProductId"], ProductName = sd["ProductName"].ToString(), Rate = (decimal)sd["Rate"], Description = sd["Description"].ToString(), CategoryName = sd["CategoryName"].ToString() };
            }
            cmd.ExecuteNonQuery();
            con.Close();
            return View(pr);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pd)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Exam;Integrated Security=True;";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProduct";

            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.Parameters.AddWithValue("@ProductName", pd.ProductName);
            cmd.Parameters.AddWithValue("@Rate", pd.Rate);
            cmd.Parameters.AddWithValue("@Description", pd.Description);
            cmd.Parameters.AddWithValue("@CategoryName", pd.CategoryName);

            try
            {

                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                con.Close();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
