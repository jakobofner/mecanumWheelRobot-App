using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Text;

namespace mecanumWheelRobot.Bluetooth
{
    class checkConnection
    {
        public static bool checkScannerConnected()
        {
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            if (adapter == null)
                System.Diagnostics.Debug.WriteLine("checkScannerConnected(): No Bluetooth adapter found.");

            if (!adapter.IsEnabled)
                System.Diagnostics.Debug.WriteLine("checkScannerConnected(): Bluetooth adapter is not enabled.");

            BluetoothDevice device = null;

            foreach (var bd in adapter.BondedDevices)
            {
                if (bd.Name.StartsWith("mecanumWheelRobot"))
                {
                    device = bd;
                    break;
                }
            }

            if (device == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
