﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        public string email { get; set; }
        public string password { get; set; }
        public int passcode { get; set; }

        public string Login(string email, string password)
        {
            // Use properties instead of method parameters
            this.email = email;
            this.password = password;

         
            // Use == for equality check
            if (this.email == "nehash@gmail.com" && this.password == "nehash@123")
            {
                return "Success";
            }
            else
            {
                return "not valid";
            }
        }
    }
}
