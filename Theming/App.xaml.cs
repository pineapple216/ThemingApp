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