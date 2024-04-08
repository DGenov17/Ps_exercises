using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            user.Name = "Test";
            user.Password = "test password";
            user.Role = Others.UserRolesEnum.ADMIN;

            UserViewModel userViewModel = new UserViewModel(user);

            UserView userView = new UserView(userViewModel);
            userView.Display();
        }
    }
}
