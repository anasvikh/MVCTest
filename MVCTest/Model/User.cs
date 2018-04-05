using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        //public List<Image> Images { get; set; }


        public User()
        {
            //Images = new List<Image>();
        }

        public User(string userName)
        {
            UserName = userName;
        }
    }
}
