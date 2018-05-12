using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismNavigationService.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
        }


        private DelegateCommand _gotoTags;
        public DelegateCommand GotoTags =>
            _gotoTags ?? (_gotoTags = new DelegateCommand(ExecuteGotoTags));

        async void ExecuteGotoTags()
        {
            await NavigationService.NavigateAsync("tags");
        }


        private DelegateCommand _gotoCustLayout;
        public DelegateCommand GotoCustLayout =>
            _gotoCustLayout ?? (_gotoCustLayout = new DelegateCommand(ExecuteGotoCustLayout));

       async void ExecuteGotoCustLayout()
        {
            await NavigationService.NavigateAsync("custLayout");

        }
    }
}
