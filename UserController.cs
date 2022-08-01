using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Model;
using TaskManagementApplication.App_Data;

namespace TaskManagementApplication.Controller
{
    public class UserController
    {

        UserData userData = new UserData();

        public void CreateUser()
        {
            userData.SetUser();
        }
        
        //   Check User

        public bool IsValidUser(int id, string name)
        {
            bool result = userData.IsValidUser(id, name);
            return result;
        }






      
    }
}
