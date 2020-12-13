using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using CineSaltoDeFe.Models;
namespace CineSaltoDeFe.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = " data source =DESKTOP-GR3RPN9; database = cine; integrated segurity = SSPI ";        }
        public ActionResult Verificar( Login log)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select into nombre,Password from Users where username ='"+log.Nombre+ "'and password ='" + log.contrasena+ "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Catelera");
            }
            else
            {
                con.Close();
                return View();
            }
        }


    }
}