using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;
using WelcomeExtended.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData()
        {
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            _nextId++;
        }

        public void DeleteUser(User user)
        {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if (user.Name == name && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Name == name && x.Password == password).FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var check = from user in _users
                        where user.Name == name && user.Password == password
                        select user;
            return check.Any();
        }

        public User GetUser(string name, string password)
        {
            var foundUser = _users.Where(x => x.Name == name && x.Password == password).FirstOrDefault();

            if (foundUser != null)
            {
                return foundUser;
            }
            throw new ArgumentOutOfRangeException("No user found");
        }

        public void AssignUserRole(string name, string role)
        {
            try
            {
                var convertedRole = Enum.Parse(typeof(UserRolesEnum), role, true);
                var foundUser = _users.Where(x => x.Name == name).FirstOrDefault();
                if (foundUser != null)
                {
                    foundUser.Role = (UserRolesEnum)convertedRole;
                }
            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            var foundUser = _users.Where(x => x.Name == name).FirstOrDefault();
            if (foundUser != null)
            {
                foundUser.Role = role;
            }
        }

        public void SetActive(string name, DateTime expiration)
        {
            var foundUser = _users.Where(x => x.Name == name).FirstOrDefault();
            if (foundUser != null)
            {
                foundUser.Expires = expiration;
            }
        }
    }
}
