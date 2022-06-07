using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace mecanumWheelRobot.Bluetooth
{
	public interface IBth
	{
		void Start(string name, int sleepTime, bool readAsCharArray);
		void Write(string writeValue);
		void Cancel();

		ObservableCollection<string> PairedDevices();
	}
}
