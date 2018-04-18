using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Theming.Resources;
using Theming.ServiceLayer;
using Xamarin.Forms;

namespace Theming
{
    public partial class ThemingPage : ContentPage
    {
        static bool _isToggled = false;


        public ThemingPage()
        {
            InitializeComponent();
            //LoadColors();

            #if ONT
            TestLabel.Text = "ONT Build";
            #elif TST
            TestLabel.Text = "TST Build";
            #elif ACC
            TestLabel.Text = "ACC Build";
            #elif PROD
            TestLabel.Text = "PROD Build";
            #endif
        }

        //private async Task LoadColors()
        //{
        //    var tasks = new List<Task>();
        //    var colorTask = Task.Run(async () => await AppColors.Instance.InitializeColors());
        //    tasks.Add(colorTask);
        //    await Task.WhenAll(tasks);
        //}

        async void OnChangeStyleClicked(object sender, System.EventArgs e)
        {
            Debug.WriteLine(">> Before OnChangeStyleClicked");
            MyLabel.Text = "Start ...";
            await ServiceLogic.Instance.LoadAsync();
            MyLabel.Text = "End ...";
            Debug.WriteLine(">> After OnChangeStyleClicked");
        }
    }
}
