using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Model
{
    public class UserInfo
    {
        public UserInfo() { }
        public string userName { get; set; }
        public string password { get; set; }
        public string url { get; set; }

        public override string ToString()
        {
            return userName;
        }
    }
}