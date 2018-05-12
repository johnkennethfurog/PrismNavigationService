using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismNavigationService.ViewModels
{
	public class TagEntryPageViewModel : ViewModelBase
	{

        ObservableCollection<Tags> Tags { get; } = new ObservableCollection<Tags>();

        public TagEntryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "TAGS";

            Tags.Add(new Tags { Tag = "#prsim" });
            Tags.Add(new Tags { Tag = "#prsim" });
            Tags.Add(new Tags { Tag = "#prsim" });
            Tags.Add(new Tags { Tag = "#prsim" });
            Tags.Add(new Tags { Tag = "#prsim" });
            Tags.Add(new Tags { Tag = "#prsim" });
        }


        
    }

    class Tags
    {
        public string Tag { get; set; }
    }
}
