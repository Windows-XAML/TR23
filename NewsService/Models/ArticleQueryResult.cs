using Newtonsoft.Json;

namespace NewsService.Models
{
    [JsonObject]
    public class ArticleQueryResult<T>
    {
        [JsonProperty("total_count")]
        public int TotalCount
        {
            get;
            set;
        }

        [JsonProperty("incomplete_results")]
        public bool IncompleteResults
        {
            get;
            set;
        }

        [JsonProperty("items")]
        public T[] Items
        {
            get;
            set;
        }

        [JsonProperty("message")]
        public string ErrorMessage
        {
            get;
            set;
        }
    }
}