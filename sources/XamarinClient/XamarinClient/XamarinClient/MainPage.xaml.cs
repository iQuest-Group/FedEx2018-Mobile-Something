using Xamarin.Forms;
using XamarinClient.Pages;
using XamarinClient.ViewModels;

namespace XamarinClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Navigation.PushModalAsync(new LoginPage(new LoginViewModel()));
        }
    }
}