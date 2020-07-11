﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GithubUsers
{
    public partial class App : Application
    {
        public static string ApiUrl { get; private set; }
        public App()
        {
            InitializeComponent();
            Init();
        }

        private async Task Init()
        {
            await LoadConfig();
            MainPage = new NavigationPage(new MainPage());
        }

        private static async Task LoadConfig()
        {
            var assembly = Assembly.GetAssembly(typeof(App));
            var resourceNames = assembly.GetManifestResourceNames();
            var config = resourceNames.FirstOrDefault(x => x.Contains("config.json"));

            using (var stream = assembly.GetManifestResourceStream(config))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = await reader.ReadToEndAsync();
                    var dynamicJson = JObject.Parse(json);

                    ApiUrl = dynamicJson["apiUrl"].Value<string>();
                }
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
