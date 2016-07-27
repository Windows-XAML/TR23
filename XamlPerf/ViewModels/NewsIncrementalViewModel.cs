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
        //-- old one
        // private DataService _dataService;
        //-- incremental one...
        private INewsService _service;
        public NewsServiceIncrementalItemSource _articlesSource;

        public IncrementalLoadingCollection<Article, NewsServiceIncrementalItemSource> Articles { get; private set; }

        public Article Article { get; set; }

        public NewsIncrementalViewModel()
        {
            //-- new one
            _service = new NewsService.Incremental.NewsService(); // i know.. i know - defeates DI. just temporary.
            _articlesSource = new NewsServiceIncrementalItemSource(_service);
            Articles = new IncrementalLoadingCollection<Article, NewsServiceIncrementalItemSource>(_articlesSource);


            //}
        }

        #region properties


        string _FilterString = string.Empty;
        public string FilterString { get { return _FilterString; } set { Set(ref _FilterString, value); } }

        #endregion

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            // load articles
            //_originalItems = await _dataService.GetArticlesAsync();

            // restore filter string, if any
            if (suspensionState.ContainsKey(nameof(FilterString)))
            {
                FilterString = suspensionState[nameof(FilterString)]?.ToString();
            }
            else if (parameter as string != null)
            {
                FilterString = parameter?.ToString();
            }

            // apply initial filter
            Filter();
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            if (suspending)
            {
                suspensionState[nameof(FilterString)] = FilterString;
            }
            return Task.CompletedTask;
        }

        public void Filter()
        {
            //TODO: call NewsService for Filter operation now..
            //var filter = _originalItems.Where(x => x.Headline.ToLower().Contains(FilterString?.ToLower()));
            //Items.AddRange(filter, true);
        }

      

    }
}

