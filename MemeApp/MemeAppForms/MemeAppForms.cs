using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace MemeAppForms
{
    public class MemeModel
    {
        public string ImageUrl { get; set; }

        public string DisplayName { get; set; }
    }

    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new OverviewPage());
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

