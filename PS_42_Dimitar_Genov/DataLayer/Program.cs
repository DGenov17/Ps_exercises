using DataLayer.Database;
using DataLayer.Extensions;
using DataLayer.Model;
using System.Runtime.CompilerServices;
using Welcome.Others;

namespace DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise4();
        }

        private static void Exercise4()
        {
            Console.WriteLine("Enter credentials:");
            Console.Write("name: ");
            var enteredName = Console.ReadLine();
            Console.Write("password: ");
            var eneteredPassword = Console.ReadLine();

            using (var context = new DatabaseContext()) 
            {
                context.Database.EnsureCreated();
                context.Add<DatabaseUser>(new DatabaseUser()
                {
                    Name = "user",
                    Password = "password",
                    Expires = DateTime.UtcNow,
                    Role = UserRolesEnum.STUDENT
                });

                context.SaveChanges();
                var users = context.Users.ToList();
                users.CheckValidUser(enteredName, eneteredPassword);
            }
        }
    }
}
