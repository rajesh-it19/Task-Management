using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.Model;

namespace TaskManagementApplication.App_Data
{

        public class UserData
        {
            private static List<UserData> _user = new List<UserData>();

            //  User Repository




            public int UserId { get; set; }
            public string UserName { get; set; }


            public void SetUser()
            {
                int[] id = new int[]
                {
                100,101,102
                };
                string[] name = new string[]
                {
                "RAJESH S",
                "SATHISH R",
                "PRIYA R"
                };
                for (int i = 0; i < 3; i++)
                {
                    var user = new UserData();
                    user.UserId = id[i];
                    user.UserName = name[i];
                    UserData._user.Add(user);
                }
            }


            public bool IsValidUser(int id, string name)
            {
                foreach (var user in UserData._user)
                {
                    if (user.UserId == id && user.UserName == name)
                    {
                        Model.User userModel = new Model.User(id, name);
                        return true;
                    }
                }
                return false;

            }












        }
    }





