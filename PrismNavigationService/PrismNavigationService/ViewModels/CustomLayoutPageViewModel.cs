using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismNavigationService.ViewModels
{
	public class CustomLayoutPageViewModel : ViewModelBase
	{

        public ObservableCollection<string> ImagesSources { get; } = new ObservableCollection<string>();

        public CustomLayoutPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            ImagesSources.Add("https://www.king.senate.gov/imo/media/image/2013%20Senator%20King%20Official%20Portrait1.jpg");
            ImagesSources.Add("https://www.king.senate.gov/imo/media/image/2013%20Senator%20King%20Official%20Portrait1.jpg");
            ImagesSources.Add("https://www.king.senate.gov/imo/media/image/2013%20Senator%20King%20Official%20Portrait1.jpg");
            ImagesSources.Add("https://www.king.senate.gov/imo/media/image/2013%20Senator%20King%20Official%20Portrait1.jpg");
            ImagesSources.Add("https://www.king.senate.gov/imo/media/image/2013%20Senator%20King%20Official%20Portrait1.jpg");
        }
    }
}
