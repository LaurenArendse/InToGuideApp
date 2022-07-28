﻿using InToGuideApp.Services.Interfaces;
using InToGuideWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InToGuideApp.Services
{
    public class AuthenticationService :IAuthentication
    {

        private HttpClient _httpClient;
        private IAppConfiguration _config;

        public AuthenticationService(IAppConfiguration config, IHttpNativeHandler handler)
        {
            _httpClient = new HttpClient(handler.GetHttpClientHandler());
            _config = config;
        }

        public async Task<bool> Authenticate(string emailAddress, string password)
        {
            Uri uri = new Uri(_config.InToGuideServerUrl + "api/Authentication");

            try
            {
                var request = new AuthenticationRequest() { EmailAddress = emailAddress, Password = password };
                string requestJson = JsonConvert.SerializeObject(request);

                StringContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _httpClient.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    var contentResponse = await response.Content.ReadAsStringAsync();

                    var valueResponse = JsonConvert.DeserializeObject<bool>(contentResponse);

                    return valueResponse;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return false;
        }
    }
}
