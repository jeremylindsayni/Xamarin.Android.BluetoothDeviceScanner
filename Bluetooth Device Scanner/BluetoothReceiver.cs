using System;
using System.Linq;
using System.Collections.Generic;
using Android.Bluetooth;
using Android.Content;

namespace Bluetooth_Device_Scanner
{
    public class BluetoothReceiver : BroadcastReceiver
    {
        //public delegate void BluetoothDeviceDetectedEventHandler(object source, BluetoothReceiverEventArgs e);

        public BluetoothAdapter BluetoothAdapter { get; set; }

        public BluetoothReceiver()
        {
            if (BluetoothAdapter == null)
            {
                BluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            }

            if (BluetoothAdapter == null)
            {
                throw new Exception("No Bluetooth adapter found.");
            }

            if (!BluetoothAdapter.IsEnabled)
            {
                throw new Exception("Bluetooth adapter is not enabled.");
            }
        }

        public IEnumerable<BluetoothDevice> RegisteredBluetoothDevices
        {
            get
            {
                var devices = from bluetoothDevice
                              in BluetoothAdapter.BondedDevices
                              select bluetoothDevice;

                if (devices == null)
                {
                    throw new Exception("Named device not found.");
                }

                return devices;
            }
        }

        public void ScanForUnregisteredDevices()
        {
            var isStartedDiscovery = BluetoothAdapter.StartDiscovery();

            if (!isStartedDiscovery)
            {
                throw new Exception("Bluetooth device discovery not started");
            }
        }

        public void StopScanForUnregisteredDevices()
        {
            BluetoothAdapter.CancelDiscovery();
        }

        public override void OnReceive(Context context, Intent intent)
        {
            string action = intent.Action;

            if (action == BluetoothDevice.ActionFound)
            {
                // Get device
                BluetoothDevice newDevice = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);

                // now you could do your job with newDevice
                // etc. check if newDevice is not already in a list and then use it in a ListView
                
                //DeviceDetected?.Invoke(this, new BluetoothReceiverEventArgs(newDevice.Name));

                //Console.WriteLine("*****");
                //Console.WriteLine(newDevice.Address);
                //Console.WriteLine(newDevice.Name);
                //Console.WriteLine("*****");
            }
        }
    }

    public class BluetoothReceiverEventArgs : EventArgs
    {
        private readonly string eventInfo;

        public BluetoothReceiverEventArgs(string text)
        {
            eventInfo = text;
        }

        public string GetInfo()
        {
            return eventInfo;
        }
    }
}