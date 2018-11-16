using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinClient.Dto;
using XamarinClient.Models;
using XamarinClient.Pages;
using XamarinClient.Services;

namespace XamarinClient.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            User = new User();
            Login = new Command(async a => await OnLoginClicked());
        }



        public User User { get; set; }

        public ICommand Login { get; set; }
        public INavigation Navigation { get; set; }

        private async Task OnLoginClicked()
        {
            if (string.IsNullOrEmpty(User.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter a name", "Cancel");
                return;
            }

            var service = new GameService();
            var id = await service.Register(new UserDto{Name = User.Name});

            if (string.IsNullOrEmpty(id))
            {

                await Application.Current.MainPage.DisplayAlert("Error", "Register failed", "Cancel");
                return;
            }

            User.Id = id;
            await Navigation.PushModalAsync(new GamePage(new GameViewModel(User)));
        }
    }
}