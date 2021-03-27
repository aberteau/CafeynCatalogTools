using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CafeynCatalogTools.Core.CafeynAPI.Data
{
    public class Store
    {
        [JsonProperty("storeId")]
        public Int32 StoreId { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("code")]
        public String Code { get; set; }

        [JsonProperty("categories")]
        public IEnumerable<Category> Categories { get; set; }
    }
}