using System;
using Newtonsoft.Json;

namespace CafeynCatalogTools.Core.CafeynAPI.Data
{
    public class CategoryItem
    {
        [JsonProperty("publicationId")]
        public Int32 PublicationId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }
    }
}