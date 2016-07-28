using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Utils;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace XamlPerf.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BitmapInefficient : Page
    {
        public BitmapInefficient()
        {
            Services.LoggingService.AddUserMark("Start Bitmap/Inefficient");
            this.InitializeComponent();
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                Items.AddRange(await new Services.DataService.DataService().GetImagesAsync());
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            GC.Collect();
        }

        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();
    }
}
