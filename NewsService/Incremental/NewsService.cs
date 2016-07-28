using NewsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewsService.Incremental
{
    public class NewsService : INewsService
    {
        private static NewsCache cache = null;

        public NewsService()
        {
            if (cache == null)
            {
                cache = new NewsCache();
            }
        }

        public const int PAGE_SIZE = 10;

        public async Task<Article> GetArticleAsync(int id)
        {
            return null;
            //cache.get
        }

        public async Task<ArticleQueryResult<Article>> GetArticlesAsync(string query, int pageIndex = 1)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (pageIndex <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }

            var result = await cache.GetArticlesQueryResultAsync(pageIndex, 20); //TODO: page it correctly

            return result;
        }
    }
}
