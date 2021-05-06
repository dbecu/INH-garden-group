using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenGroupModel
{
    public class Session
    {
        private static Session instance;
        public static Session Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new Session();
                return instance;
            } 
        }

        private User loggedInUser;
        public User LoggedInUser
        {
            get
            {
                return loggedInUser;
            }
            set
            {
                if (loggedInUser == null)
                    loggedInUser = value;
            }
        }

        private Session() { }
    }
}
