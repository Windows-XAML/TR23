using System;
using Template10.Utils;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace XamlPerf.Views
{
    public sealed partial class MailRelativePanel : Page
    {
        public MailRelativePanel()
        {
            Services.LoggingService.AddUserMark("Start Mail/RelativePanel");
            Loaded += async (s, e) => await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => { Services.LoggingService.AddUserMark("Loaded Mail/RelativePanel"); });
            this.InitializeComponent();
        }

        public bool[] Accounts => new[] { true, false, false };
        public bool[] Folders => new[] { true, false, false, false, false };
        public SolidColorBrush[] Messages => new[] { Colors.Transparent.ToSolidColorBrush(), Colors.SteelBlue.ToSolidColorBrush(), Colors.SteelBlue.ToSolidColorBrush(), Colors.Transparent.ToSolidColorBrush(), Colors.Transparent.ToSolidColorBrush(), Colors.SteelBlue.ToSolidColorBrush(), Colors.Transparent.ToSolidColorBrush() };
    }
}
