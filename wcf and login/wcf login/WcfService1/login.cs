using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1
{
    public class login
    {
        TestDBEntities ME = new TestDBEntities();
        public string vusername;
        public string vpassword;

        public string Username
        {
            get { return vusername; }
            set { vusername = value; }
        }

        public string Password
        {
            get { return vpassword; }
            set { vpassword = value; }
        }

        public string UserLogin()
        {
            try
            {
                var login = (from userdata in ME.userdatas
                             where (userdata.USERNAME == vusername && userdata.PASSWORD == vpassword)
                             select userdata).Count() > 0;
                if (login)
                {
                    return "true";
                }
                else
                    return "false";

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
