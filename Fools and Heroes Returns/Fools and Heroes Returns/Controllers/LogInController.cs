using Fools_and_Heroes_Returns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

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
            //System.Data.SqlClient.SqlConnection connection;
            //connection = new System.Data.SqlClient.SqlConnection();
            //connection.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename='C:\\Dev\\FnHReturns\\Fools and Heroes Returns\\Fools and Heroes Returns\\App_Data\\PlayerDatabase.mdf';Integrated Security=True";

            //SqlCommand command = new SqlCommand();
            //SqlDataReader reader;

            //command.CommandText = "SELECT UserName, Password FROM Members";
            //command.CommandType = System.Data.CommandType.Text;
            //command.Connection = connection;

            //connection.Open();
            //reader = command.ExecuteReader();
            // //return 1 if no results returned

            // //check that user name provided matches a username in the database
            // //return 1 if username not found

            // //if username exists check that password provided matches password in database
            // //return 2 if password is incorect
            //connection.Close();


            return 3;
        }
    }
}
