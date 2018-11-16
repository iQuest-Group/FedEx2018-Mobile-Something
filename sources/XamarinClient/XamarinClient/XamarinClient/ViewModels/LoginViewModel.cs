using System.Windows.Input;
using Xamarin.Forms;
using XamarinClient.Models;
using XamarinClient.Pages;

namespace XamarinClient.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            User = new User();
            Login = new Command(a => OnLoginClicked());
        }

        public User User { get; set; }

        public ICommand Login { get; set; }
        public INavigation Navigation { get; set; }

        private void OnLoginClicked()
        {
            Navigation.PushModalAsync(new GamePage(new GameViewModel(User)));
        }
    }
}