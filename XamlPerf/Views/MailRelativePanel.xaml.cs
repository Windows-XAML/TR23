using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Utils;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Diagnostics;
using Windows.UI;
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
