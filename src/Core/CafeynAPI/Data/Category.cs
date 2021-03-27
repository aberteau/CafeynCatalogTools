using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CafeynCatalogTools.Core.CafeynAPI.Data
{
    public class Category
    {
        [JsonProperty("id")]
        public Int32 Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("items")]
        public IEnumerable<CategoryItem> Items { get; set; }
    }
}