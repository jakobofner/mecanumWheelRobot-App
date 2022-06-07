using Android.Bluetooth;
using Java.IO;
using Java.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace mecanumWheelRobot.Bluetooth
{
	class Bth : IBth
	{

		BluetoothDevice device = null;
		BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
		BluetoothSocket BthSocket = null;

		private CancellationTokenSource _ct { get; set; }
		

		const int RequestResolveError = 1000;

		public Bth()
		{
		}

		#region IBth implementation

		/// <summary>
		/// Start the "reading" loop 
		/// </summary>
		/// <param name="name">Name of the paired bluetooth device (also a part of the name)</param>
		public void Start(string name, int sleepTime = 200, bool readAsCharArray = false)
		{

			Task.Run(async () => connect(name, sleepTime, readAsCharArray));
		}

		public void Write(string writeValue)
        {
			Task.Run(async () => write(writeValue));
		}


		private async Task connect(string name, int sleepTime, bool readAsCharArray)
		{
				try
				{
					Thread.Sleep(sleepTime);

					adapter = BluetoothAdapter.DefaultAdapter;

					if (adapter == null)
						System.Diagnostics.Debug.WriteLine("No Bluetooth adapter found.");
					else
						System.Diagnostics.Debug.WriteLine("Adapter found!!");

					if (!adapter.IsEnabled)
						System.Diagnostics.Debug.WriteLine("Bluetooth adapter is not enabled.");
					else
						System.Diagnostics.Debug.WriteLine("Adapter enabled!");

					System.Diagnostics.Debug.WriteLine("Try to connect to " + name);

					foreach (var bd in adapter.BondedDevices)
					{
						System.Diagnostics.Debug.WriteLine("Paired devices found: " + bd.Name.ToUpper());
						if (bd.Name.ToUpper().IndexOf(name.ToUpper()) >= 0)
						{

							System.Diagnostics.Debug.WriteLine("Found " + bd.Name + ". Try to connect with it!");
							device = bd;
							break;
						}
					}

					/*foreach (var bd in adapter.BondedDevices)
					{
						if (bd.Name.StartsWith("BCST-70"))
						{
							device = bd;
							break;
						}
					}*/

					if (device == null)
					{
						System.Diagnostics.Debug.WriteLine("Named device not found.");
						MainThread.BeginInvokeOnMainThread(() =>
						{
							service.toast.toastSuccess("connected");
						});
					}
					else
					{
						UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");
						if ((int)Android.OS.Build.VERSION.SdkInt >= 10) // Gingerbread 2.3.3 2.3.4
							BthSocket = device.CreateInsecureRfcommSocketToServiceRecord(uuid);
						else
							BthSocket = device.CreateRfcommSocketToServiceRecord(uuid);

						if (BthSocket != null)
						{


							//Task.Run ((Func<Task>)loop); /*) => {
							await BthSocket.ConnectAsync();
							MainThread.BeginInvokeOnMainThread(() =>
							{
								service.toast.toastSuccess("connected");
							});
					}
						else
							System.Diagnostics.Debug.WriteLine("BthSocket = null");

					}


				}
				catch(Exception ex)
				{
						service.toast.toastSuccess(ex.Message);
					}

		}


		public async Task write(string write)
        {
			if (BthSocket.IsConnected)
			{
				write += "?";
				System.Diagnostics.Debug.WriteLine("writing");
				var bytes = Encoding.ASCII.GetBytes(write);
				BthSocket.OutputStream.Write(bytes, 0, bytes.Length);

            }
            else
            {
				System.Diagnostics.Debug.WriteLine("no socket");
			}
		}

		/// <summary>
		/// Cancel the Reading loop
		/// </summary>
		/// <returns><c>true</c> if this instance cancel ; otherwise, <c>false</c>.</returns>
		public void Cancel()
		{
			if (_ct != null)
			{
				System.Diagnostics.Debug.WriteLine("Send a cancel to task!");
				_ct.Cancel();
				MainThread.BeginInvokeOnMainThread(() =>
				{
					service.toast.toastError("Disconnected");
					// Code to run on the main thread
				});
			}
		}


			public ObservableCollection<string> PairedDevices()
		{
			BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
			ObservableCollection<string> devices = new ObservableCollection<string>();

			foreach (var bd in adapter.BondedDevices)
				devices.Add(bd.Name);

			return devices;
		}


		#endregion
	}
}
