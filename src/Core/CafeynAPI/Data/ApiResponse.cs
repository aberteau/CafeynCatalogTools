using Newtonsoft.Json;

namespace CafeynCatalogTools.Core.CafeynAPI.Data
{
    public class ApiResponse<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
