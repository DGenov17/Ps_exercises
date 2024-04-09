using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Extensions
{
    public static class DatabaseExtensions
    {
        public static void CheckValidUser(this List<DatabaseUser> databaseUsers, string name, string password)
        {
            var result = from user in databaseUsers
                         where user.Name == name && user.Password == password
                         select user;

            if (result.Any())
            {
                Console.WriteLine("Valid User");
            }
            else
            {
                Console.WriteLine("User Not Valid");
            }
        }
    }
}
