﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InToGuideApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace InToGuideApp.Droid.Services
{
    public class NoSslAndroidHandler : IHttpNativeHandler
    {
        public HttpClientHandler GetHttpClientHandler()
        {
            return new IgnoreSSLClientHandler();
        }
    }
}