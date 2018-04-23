using System.Collections.Generic;
using System.Threading.Tasks;
using Theming.Resources;
using Theming.ServiceLayer;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Theming
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ThemingPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            ServiceLogic.Instance.Initialize();

#if ONT
            AppCenter.Start("ios=31626597-b2fa-4fee-abc3-70456b14bb74;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                            typeof(Analytics), typeof(Crashes));
            #elif TST
            AppCenter.Start("ios=0b6b631e-8202-4205-87ea-bb7aa8302a28;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes))
            #elif ACC
            AppCenter.Start("ios=da9ac222-0ca0-4f04-af0e-95e108176d53;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes))
            #elif PROD
            AppCenter.Start("ios=8d01e0a7-2c6c-4b10-9980-780b3311292e;" +
                  "uwp={Your UWP App secret here};" +
                  "android={Your Android App secret here}",
                  typeof(Analytics), typeof(Crashes))
            #endif

            AppCenter.Start("android=7689188d-e46f-4246-afe6-df54147e2b68;" + "ios=8d01e0a7-2c6c-4b10-9980-780b3311292e", typeof(Analytics), typeof(Crashes));
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