using NewsService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NewsService.Incremental
{
    public class NewsCache
    {
        private static readonly Random NewsRandom = new Random();

        private static List<Article> _fullArticleList;

        private int _articleCount = 100;

        public NewsCache() {
            LoadData();
        }

        public async void LoadData()
        {
            //var data = await CachedArticlesAsync();
            //_fullArticleList = await Task.Run(() => JsonConvert.DeserializeObject<List<Article>>(data));
        }

        public async Task<List<Article>> GetArticlesAsync()
        {
            var result = await GetArticlesAsync(20);
            return new List<Article>(result);
        }

        public async Task<ArticleQueryResult<Article>> GetArticlesQueryResultAsync(int startIndex, int count)
        {
            ArticleQueryResult<Article> result = new ArticleQueryResult<Article>();

            //var listResult = _fullArticleList.Skip<Article>(startIndex).Take<Article>(count);
            //result.Items = listResult.ToArray<Article>();
            //result.TotalCount = _fullArticleList.Count();
            var listResult = await GetArticlesAsync(count); //TODO: page it correctly, this is just random
            result.Items = listResult.ToArray<Article>();
            return result;
        }


        public async Task<List<Article>> GetArticlesAsync(int numberOfArticles)
        {
            // async to simulate a web service call
            var result = await Task.Run(() =>
            {
                var articles = new List<Article>();
                for (var i = 0; i < numberOfArticles; i++)
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

            if (_fullArticleList == null)
            {
                var data = CachedArticlesAsync().Result;
                _fullArticleList = Task.Run(() => JsonConvert.DeserializeObject<List<Article>>(data)).Result;
            }

            var paras = new List<string>();
            for (var i = 0; i < NewsRandom.Next(5, 15); i++)
            {
                paras.Add(ArticleText.GetParagraph());
            }
            var image = $"ms-appx:///NewsService/Images/PreviewImage{NewsRandom.Next(1, 337):D2}.png";

            int imageIndex = NewsRandom.Next(0, _fullArticleList.Count());
            image = _fullArticleList[imageIndex].Image;



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
    }
}
