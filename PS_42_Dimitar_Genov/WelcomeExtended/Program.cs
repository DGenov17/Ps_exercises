using Welcome.Model;
using Welcome.Others;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Others;

namespace WelcomeExtended
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exercise2();
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
    }
}
