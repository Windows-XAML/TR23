using Template10.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;
using Windows.Storage;
using NewsService;
using Newtonsoft.Json;
using Template10.Utils;
using XamlPerf.Services.DataService;
using NewsService.Incremental;
using NewsService.Shared;

namespace XamlPerf.ViewModels
{
    public class NewsStandardViewModel : ViewModelBase
    {

        private DataService _dataService;
        private ObservableCollection<NewsService.Article> _originalItems;

        public ObservableCollection<Article> Articles
        {
            get { return _originalItems; }
            set
            {
                _originalItems = value;
                RaisePropertyChanged();

            }
        }


        public NewsStandardViewModel()
        {
            _dataService = new DataService();
            LoadItems();

        }


        public async void LoadItems()
        {
            var list = await _dataService.GetArticlesAsync();
            Articles = list.ToObservableCollection<NewsService.Article>();

        }





    }
}

