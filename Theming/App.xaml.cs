using System.Collections.Generic;
using System.Threading.Tasks;
using Theming.Resources;
using Theming.ServiceLayer;
using Xamarin.Forms;

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