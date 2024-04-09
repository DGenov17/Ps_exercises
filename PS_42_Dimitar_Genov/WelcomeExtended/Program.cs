using System.ComponentModel.DataAnnotations;
using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Data;
using WelcomeExtended.Helpers;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Exercise2();
            Exercise3();
        }

        public static void Exercise2()
        {
            try
            {
                var user = new User
                {
                    Name = "Test",
                    Password = "password",
                    Role = UserRolesEnum.ANONYMOUS
                };

                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);

                view.Display();
                view.DisplayError();

            }
            catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log);
                log(ex.Message);
            }
            finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }

        public static void Exercise3()
        {
            var userData = new UserData();
            userData.PopulateUserData();

            Console.WriteLine("Enter credentials:");
            Console.Write("name: ");
            var enteredName = Console.ReadLine();
            Console.Write("password: ");
            var eneteredPassword = Console.ReadLine();

            var validationResult = userData.ValidateCredentials(enteredName, eneteredPassword);

            if(validationResult == false)
            {
                Console.WriteLine("Credentials validation failed");
            }
            else
            {
               var result = userData.GetUserHelper(enteredName, eneteredPassword).ToStringHelper();
               Console.WriteLine(result);
            }
        }
    }
}
