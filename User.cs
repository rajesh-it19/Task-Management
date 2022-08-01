using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApplication.App_Data;

namespace TaskManagementApplication.Model
{
    public class User
    {
        

        private int _userId;         

        private string _userName;



        //initializing _userId and _username at the time of login using Constructor and assigning get only property

        public User(int id, string name)
    {
        _userId = id;
        _userName = name;
    }



    public int UserId
        {
            get
            {
                return _userId;
            }
            
        }
        public string UserName 
        { 
            get
            {
               return _userName;
            }
            
        }    
    }
}                                 