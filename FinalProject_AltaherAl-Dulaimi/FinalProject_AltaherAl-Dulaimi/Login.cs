using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_AltaherAl_Dulaimi
{
    class Login
    {
        static bool isLogin ;


        public static void setIsLogin(bool flag) {

            isLogin = flag;
        }

        public static bool getLogIn() {

            return isLogin;
        }
    }
}
