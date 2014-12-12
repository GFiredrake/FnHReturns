using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Fools_and_Heroes_Returns.Models
{
    public class LoginDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
