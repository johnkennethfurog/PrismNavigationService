using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismNavigationService.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            btnNav.Clicked += BtnNav_Clicked;
		}

        private async void BtnNav_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CustomLayoutPage());
        }
    }
}