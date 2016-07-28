using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace XamlPerf
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
        }

        public override UIElement CreateRootElement(IActivatedEventArgs e)
        {
            var frame = NavigationServiceFactory(BackButton.Attach, ExistingContent.Exclude).Frame;
            RelativePanel.SetAlignLeftWithPanel(frame, true);
            RelativePanel.SetAlignRightWithPanel(frame, true);
            RelativePanel.SetAlignBottomWithPanel(frame, true);
            return new Views.MainPage(frame);
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            await Task.CompletedTask;
        }
    }
}

