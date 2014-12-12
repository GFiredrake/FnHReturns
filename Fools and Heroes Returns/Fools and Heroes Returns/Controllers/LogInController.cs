using Fools_and_Heroes_Returns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return 1;
        }
    }
}
