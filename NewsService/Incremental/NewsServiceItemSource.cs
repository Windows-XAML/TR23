using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;
using NewsService.Shared;
using NewsService.Models;

namespace NewsService.Incremental
{
    public class NewsServiceIncrementalItemSource : IncrementalItemSourceBase<Article>
    {
        private static readonly Random NewsRandom = new Random();
        private INewsService _service;
        private int _currentPage = 0;


        public NewsServiceIncrementalItemSource(INewsService service)
        {
            _service = service;
        }


        public async Task<List<Article>> GetArticlesAsync()
        {
            var result = await GetArticlesAsync(20);
            return new List<Article>(result);
        }

        public async Task<List<Article>> GetArticlesAsync(int numberOfArticle)
        {
            // async to simulate a web service call
            var result = await Task.Run(() =>
            {
                var articles = new List<Article>();
                for (var i = 0; i < numberOfArticle; i++)
                {
                    var article = ArticleGenerator();
                    article.Id = i;
                    articles.Add(article);
                }
                return articles;
            });

            return result;
        }

        public async Task<List<Article>> GetCachedArticlesAsync()
        {
            // async to simulate a web service call
            var data = await CachedArticlesAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<List<Article>>(data));

            return result;
        }


        private static Article ArticleGenerator()
        {
            var paras = new List<string>();
            for (var i = 0; i < NewsRandom.Next(5, 15); i++)
            {
                paras.Add(ArticleText.GetParagraph());
            }
            var image = $"ms-appx:///NewsService/Images/PreviewImage{NewsRandom.Next(1, 21):D2}.png";
            return new Article
            {
                Headline = ArticleText.GetHeader(),
                Paragraphs = paras,
                Image = image,
            };
        }

        private static async Task<string> CachedArticlesAsync()
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///NewsService/Data/Data.json"));
            return await FileIO.ReadTextAsync(file);
        }

        //--- new stuff

        public string Query
        {
            get;
            set;
        }

        protected internal override async Task LoadMoreItemsAsync(ICollection<Article> collection, uint suggestLoadCount)
        {
            this.Query = "All items";
            int nextPage = this._currentPage + 1;
            ArticleQueryResult<Article> result = await this._service.GetArticlesAsync(this.Query, nextPage);
            if (result.ErrorMessage == null)
            {
                foreach (var item in result.Items)
                {
                    collection.Add(item);
                }
            }

             //   throw new NotImplementedException();
        }
    }
}