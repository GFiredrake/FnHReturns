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
    public class RegisterController : Controller
    {
        public int AttemptRegister(RegistrationDetails details)
        {

            List<RegistrationDetails> userList = new List<RegistrationDetails>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string script = "SELECT UserName, Email FROM Members";
                connection.Open();
                SqlCommand command = new SqlCommand(script, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    RegistrationDetails registrationDetails = new RegistrationDetails();
                    registrationDetails.UserName = reader["UserName"].ToString();
                    registrationDetails.Email = reader["Email"].ToString();
                    userList.Add(registrationDetails);
                }
                //check if username or email address already exists          
                foreach (RegistrationDetails detail in userList)
                {
                    //if username exists return 1
                    if (detail.UserName.ToLower() == details.UserName.ToLower())
                    {
                        return 1;
                    }
                    //if email exists return 2
                    if (detail.Email == details.Email)
                    {
                        return 2;
                    }
                    
                }
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand addCommand = new SqlCommand("INSERT INTO [CharacterReturns].[dbo].[Members](Id,FirstName,SurName,UserName,Email,Password,Branch) VALUES (@Id,@FirstName,@SurName,@UserName,@Email,@Password,@Branch)");
                    addCommand.CommandType = CommandType.Text;
                    addCommand.Connection = connection;
                    addCommand.Parameters.AddWithValue("@Id", userList.Count + 1);
                    addCommand.Parameters.AddWithValue("@FirstName", details.FirstName);
                    addCommand.Parameters.AddWithValue("@SurName", details.Surname);
                    addCommand.Parameters.AddWithValue("@UserName", details.UserName);
                    addCommand.Parameters.AddWithValue("@Email", details.Email);
                    addCommand.Parameters.AddWithValue("@Password", details.Password);
                    //will eventualy take members branch selection into acount though as we are only starting with peterborough only one branch is needed
                    addCommand.Parameters.AddWithValue("@Branch", 1);
                    connection.Open();
                    addCommand.ExecuteNonQuery();
                    return 3;
                }
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

    }
}
