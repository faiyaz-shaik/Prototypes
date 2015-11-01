using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ndpdata.Models.DataClasses
{
    public class DataService
    {

        private ICollection<User> _users;

        DataService()
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


        public IEnumerable<User> Users() {


            return _users;

        }
    }
}