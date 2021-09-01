using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_AltaherAl_Dulaimi
{
    class User: Tools
    {
        private string firstname;
        private string lastname;
        private string username;
        private string password;

        static string userInfo= ""; // user info passed around
        static string fullName = ""; // Full Name info passed around


        // Set the variables
        public void setFirstname(string firstname)
        {
            this.firstname = firstname;
        }

        public void setLastname(string lastname)
        {
            this.lastname = lastname;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        // Get of the variables

        public string getFirstname()
        {
            return this.firstname;
        }

        public string getLastname()
        {
            return this.lastname;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }


        // Tracks the Username around the application
        public static void setUserInfo(string username)
        {
            userInfo = username;
        }
        public static string getUserInfo( )
        {
            return userInfo;
        }
        

        // First and last name Held around
        public static string setFirstLastName(string name)
        {
            fullName = name;
            return fullName;
        }

        public static string getFirstLateName()
        {
            return fullName;
        }






    }
}
