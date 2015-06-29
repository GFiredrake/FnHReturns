using Fools_and_Heroes_Returns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Fools_and_Heroes_Returns.Controllers
{
    public class LogInController : Controller
    {
        public int AttemptLogIn(LoginDetails details)
        {

            if (details.UserName == null || details.Password == null)
            {
                return 0;
            }

            List<LoginDetails> logInList = new List<LoginDetails>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            string script = "SELECT UserName, Password FROM Members";
            connection.Open();
            SqlCommand command = new SqlCommand(script, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                LoginDetails logIn = new LoginDetails();
                logIn.UserName = reader["UserName"].ToString();
                logIn.Password = reader["Password"].ToString();
                logInList.Add(logIn);
            }
            connection.Close();
            if (logInList == null)
                return 1;

            foreach( LoginDetails detail in logInList)
            {
                if(detail.UserName == details.UserName)
                {
                    if(detail.Password == details.Password)
                    {
                        return 3;
                    }
                    return 2;
                }
                return 1;
            }
            return 0;
        }
    }
}
