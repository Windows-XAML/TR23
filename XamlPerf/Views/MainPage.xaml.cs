using System;
using Template10.Common;
using Windows.UI.Xaml.Controls;
using static Template10.Common.BootStrapper;

namespace XamlPerf.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage(Frame frame)
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            RelativePanel.SetBelow(frame, pageHeader);
            RootGrid.Children.Add(frame);
        }
    }
}
