using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class AdvertisementProcessor
    {
        public AdvertisementProcessor()
        {
            ApiHelper.InitializeClient();
        }

        public async Task<T> GetAdvertisements<T>(int id = 0)
        {
            string url = "https://localhost:44376/Api/Advertisements";
            
            if (id == 0)
            {
                url = "https://localhost:44376/Api/Advertisements";
            }
            else
            {
                url = $"https://localhost:44376/Api/Advertisements/{ id }";
            }

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var advertisement = await response.Content.ReadAsAsync<T>();

                    return advertisement;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
