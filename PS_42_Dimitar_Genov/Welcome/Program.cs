using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;

namespace Welcome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
        }

        public static void Exercise1()
        {
            User user = new User()
            {
                Name = "Test",
                Password = "test password",
                Role = Others.UserRolesEnum.ADMIN
            };
            UserViewModel userViewModel = new UserViewModel(user);
            UserView userView = new UserView(userViewModel);
            userView.Display();
        }
    }
}
