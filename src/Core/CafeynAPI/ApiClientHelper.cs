using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CafeynCatalogTools.Core.CafeynAPI.Data;
using Newtonsoft.Json;

namespace CafeynCatalogTools.Core.CafeynAPI
{
    public class ApiClientHelper
    {
        public static async Task<IEnumerable<Store>> GetStoresAsync()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("https://api.lekiosk.com/api/v1/partner/bouygues/publications/stores/1/publicationTypes/1?timestamp=161688300793300");
            string contentString = await httpResponseMessage.Content.ReadAsStringAsync();

            if (String.IsNullOrWhiteSpace(contentString))
                return null;

            PublicationApiResponse apiResponse = JsonConvert.DeserializeObject<PublicationApiResponse>(contentString);
            return apiResponse?.Result;
        }
    }
}
