using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinClient.ViewModels;

namespace XamarinClient.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            BindingContext = loginViewModel;
            loginViewModel.Navigation = Navigation;
        }
    }
}