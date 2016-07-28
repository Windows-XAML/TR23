using NewsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsService.Incremental
{
    public interface INewsService
    {
        Task<ArticleQueryResult<Article>> GetArticlesAsync(string query, int pageIndex = 1);
    }
}
