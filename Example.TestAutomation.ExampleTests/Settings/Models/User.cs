using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.TestAutomation.DemoTests.Settings.Models
{
    public class User
    {
        public User(string userName, string password, string apiPassword = "")
        {
            UserName = userName;
            Password = password;
            ApiPassword = apiPassword;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApiPassword { get; set; }
        public string CarrierId { get; set; }
    }
}
