using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Theming.Resources;
using Xamarin.Forms;

namespace Theming.ServiceLayer
{
    public class ServiceLogic
    {
        static Lazy<ServiceLogic> _instance = new Lazy<ServiceLogic>(() => new ServiceLogic());
        public static ServiceLogic Instance { get { return _instance.Value; } }

        const string colorsJsonV1 = "{\"LbgcString\": \"#FF69B4\",\"LtcString\": \"#FFFFFF\"}";
        const string colorsJsonV2 = "{\"LbgcString\": \"#008141\",\"LtcString\": \"#ffffff\"}";
        bool isColorsJsonV1Loaded = false;

        public void Initialize()
        {
            LoadAsync();
        }

        public async Task LoadAsync()
        {
            var tasks = new List<Task>();
            var loadColorstask = Task.Run(async () => await LoadColorsAsync());
            tasks.Add(loadColorstask);

            await Task.WhenAll(tasks);

            Debug.WriteLine(">> LOAD  ASYNC");
        }

        async Task LoadColorsAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(2000);

                    //var colorsJson = File.ReadAllText("Resources/AppColors.json");
                    var colorsJson = isColorsJsonV1Loaded ? colorsJsonV2 : colorsJsonV1;
                    isColorsJsonV1Loaded = !isColorsJsonV1Loaded;

                    var appColors = JsonConvert.DeserializeObject<AppColors>(colorsJson);

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.Resources["lbgc"] = Color.FromHex(appColors.LbgcString);
                        Application.Current.Resources["ltc"] = Color.FromHex(appColors.LtcString);
                    });
                });

                Debug.WriteLine(">> LOAD COLOR ASYNC");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($">> {ex.Message}");
                throw ex;
            }
        }
    }
}
