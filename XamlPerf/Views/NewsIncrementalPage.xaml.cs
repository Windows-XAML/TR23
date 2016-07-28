using System;
using XamlPerf.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.Foundation.Metadata;
using Windows.UI;

namespace XamlPerf.Views
{
    public sealed partial class NewsIncrementalPage : Page
    {
        public NewsIncrementalPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }
    }

}
