using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AuxiliarDoProatec.Droid;
using AuxiliarDoProatec.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

[assembly: Dependency(typeof(DependencyServices))]
namespace AuxiliarDoProatec.Droid
{
    public class DependencyServices : IOpenFile
    {
        public async Task<FileResult> PickAFile()
        {
            try
            {
                return await FilePicker.PickAsync(FileType());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private PickOptions FileType()
        {
            var custom = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>> {

             { DevicePlatform.Android, new[] { "text/comma-separated-values" } },
                  });

           return new PickOptions { FileTypes = custom, PickerTitle = "Selecione um arquivo .csv" };
        }
    }
}