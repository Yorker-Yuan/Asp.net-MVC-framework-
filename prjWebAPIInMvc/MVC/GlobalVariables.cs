﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC
{
    public static class GlobalVariables
    {
        public static HttpClient webAPIClient = new HttpClient();
        static GlobalVariables()
        {
            webAPIClient.BaseAddress = new Uri("https://localhost:44381/api/");
            webAPIClient.DefaultRequestHeaders.Clear();
            webAPIClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}