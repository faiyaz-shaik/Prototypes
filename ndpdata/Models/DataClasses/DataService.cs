using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ndpdata.Models.DataClasses
{
    public class DataService
    {

        private List<User> _users = new List<User>();

        public DataService()
        {
            _users.Add(new User {
                Id = 1, Name = "Faiyaz Shaik"
            });

            _users.Add(new User
            {
                Id = 2,
                Name = "Safura Bibi"
            });

            _users.Add(new User
            {
                Id = 3,
                Name = "Zaynab Zahra"
            });

        }


        public List<User> Users() {


            return _users;

        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

    }
}