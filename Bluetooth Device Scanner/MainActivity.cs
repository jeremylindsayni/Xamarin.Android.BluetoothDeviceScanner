using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Collections.Generic;

namespace Bluetooth_Device_Scanner
{
    [Activity(Label = "Bluetooth Device Scanner", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var item = new List<IListItem>();

            item.Add(new HeaderListItem("PREVIOUSLY PAIRED"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));
            item.Add(new HeaderListItem("AVAILABLE"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));
            item.Add(new DataItem("Bluetooth Device Name", "Device Mac Address"));

            ListView lst = FindViewById<ListView>(Resource.Id.lstview);
            lst.Adapter = new ListViewAdapter(this, item);
        }
    }
}