using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinClient.Models;
using XamarinClient.ViewModels;

namespace XamarinClient.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
		public GamePage(GameViewModel gameViewModel)
		{
			InitializeComponent ();
		    BindingContext = gameViewModel;
		    gameViewModel.Navigation = Navigation;
		}
	}
}