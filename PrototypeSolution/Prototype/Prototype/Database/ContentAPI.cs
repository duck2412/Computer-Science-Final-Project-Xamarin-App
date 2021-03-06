﻿using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Prototype.Database
{
    public class ContentApi : IContentApi
    {
        private readonly HttpClient _client;

        public ContentApi()
        {
            //Initialize httpclients using variables stored in the Constants class
            _client = new HttpClient();
            var authData = $"{Constants.ContentApiUsername}:{Constants.ContentApiKey}";
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            _client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public Task<string> DownloadArticle(string contentUrl)
        {
            //Full url example: https://content.watchmedier.dk/api/finanswatch/content/article/9517468
            var uri = new Uri(contentUrl);

            return DownloadJson(uri);
        }
        
        public Task<string> DownloadLatestArticles()
        {
            //Full url example: "https://content.watchmedier.dk/api/finanswatch/content/latest?hoursago=168&max=100"
            var uri = new Uri(Constants.ContentApiUrl + "finanswatch/content/latest?hoursago=168&max=100");
            return DownloadJson(uri);
        }

        public Task<string> DownloadSection(string sectionContentUrl)
        {
            //Full url example: "https://content.watchmedier.dk/api/finanswatch/content/latest?hoursago=500&max=30&section=fw_finansnyt_penge"
            var uri = new Uri($"{Constants.ContentApiUrl}{sectionContentUrl}");
            return DownloadJson(uri);
        }

        public async Task<string> DownloadJson(Uri uri)
        {
            try
            {
                var response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }

            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
                return "";
            }
        }

        public void DisposeClient()
        {
            _client.Dispose();
        }
    }
}
