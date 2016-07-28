using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Template10.Common;

namespace XamlPerf.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            NavigationService = BootStrapper.Current.NavigationService;
        }

        public void GoToMailRelativePanel() { NavigationService.Navigate(typeof(Views.MailRelativePanel)); }
        public void GoToMailStandard() { NavigationService.Navigate(typeof(Views.MailStandard)); }
        public void GoToTextPage() { NavigationService.Navigate(typeof(Views.TextPage)); }
        public void GoToBitmapEfficient() { NavigationService.Navigate(typeof(Views.BitmapEfficient)); }
        public void GoToBitmapInefficient() { NavigationService.Navigate(typeof(Views.BitmapInefficient)); }
        public void GoToNewsStandard() { NavigationService.Navigate(typeof(Views.NewsStandardPage)); }
        public void GoToNewsIncremental() { NavigationService.Navigate(typeof(Views.NewsIncrementalPage)); }
    }
}

