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
    public class NewsIncrementalViewModel : ViewModelBase
    {
        private INewsService _service;
        public NewsServiceIncrementalItemSource _articlesSource;

        public IncrementalLoadingCollection<Article, NewsServiceIncrementalItemSource> Articles { get; private set; }

        public NewsIncrementalViewModel()
        {
            _service = new NewsService.Incremental.NewsService(); // i know.. i know - defeates DI. just temporary.
            _articlesSource = new NewsServiceIncrementalItemSource(_service);
            Articles = new IncrementalLoadingCollection<Article, NewsServiceIncrementalItemSource>(_articlesSource);
        }


    }
}

