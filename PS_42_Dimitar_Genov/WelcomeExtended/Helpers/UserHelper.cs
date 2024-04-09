using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Data;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToStringHelper(this User user)
        {
            return $"\nusername: {user.Name},\npassword: {user.Password},\nrole: {user.Role},\nexpires: {user.Expires}\n";
        }

        public static bool ValidateCredentials(this UserData users, string? name, string? password)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException($"The Name cannot be empty");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException($"The Password cannot be empty");
            }
            return users.ValidateUser(name, password);
        }

        public static User GetUserHelper(this UserData users, string name, string password)
        {
            return users.GetUser(name, password);
        }

        public static UserData PopulateUserData(this UserData users)
        {
            var listOfUsers = new List<User>
            {
                new User() {Name = "student", Password = "123", Role = UserRolesEnum.STUDENT },
                new User() {Name = "Student2",Password = "123",Role = UserRolesEnum.STUDENT},
                new User() {Name = "Teacher",Password = "1234",Role = UserRolesEnum.PROFESSOR},
                new User() {Name = "Admin",Password = "12345",Role = UserRolesEnum.ADMIN}
            };

            foreach (var user in listOfUsers)
            {
                users.AddUser(user);
            }

            return users;
        }
    }
}
