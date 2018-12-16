using Android.Bluetooth;
using Android.Content;
using Bluetooth_Device_Scanner.ListView;

namespace Bluetooth_Device_Scanner
{
    public class BluetoothDeviceReceiver : BroadcastReceiver
    {
        public static BluetoothAdapter Adapter => BluetoothAdapter.DefaultAdapter;

        public override void OnReceive(Context context, Intent intent)
        {
            var action = intent.Action;

            // Found a device
            switch (action)
            {
                case BluetoothDevice.ActionFound:
                    // Get the device
                    var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

                    // Only update the adapter with items which are not bonded
                    if (device.BondState != Bond.Bonded)
                    {
                        MainActivity.GetInstance().UpdateAdapter(new DataItem(device.Name, device.Address));
                    }

                    break;
                case BluetoothAdapter.ActionDiscoveryStarted:
                    MainActivity.GetInstance().UpdateAdapterStatus("Discovery Started...");
                    break;
                case BluetoothAdapter.ActionDiscoveryFinished:
                    MainActivity.GetInstance().UpdateAdapterStatus("Discovery Finished.");
                    break;
                default:
                    break;
            }
        }
    }
}