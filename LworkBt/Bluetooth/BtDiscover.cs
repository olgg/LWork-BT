using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace LworkBt
{
	public class BtDiscover
	{
		private BluetoothDeviceInfo device;
		private Guid deviceGiud;
		private bool inRange = false;
		private Action<string> newMessage;

		public BtDiscover(string deviceName, Action<string> newMessage = null)
		{
			DeviceName = deviceName;
			this.newMessage = newMessage;
			Ready = false;
		}

		public string DeviceName { get; private set; }

		public bool Ready { get; private set; }

		public bool InRange
		{
			get { return inRange; }
		}

		public void InitDevice()
		{
			Ready = false;
			var cli = new BluetoothClient();
			SendMessage("Поиск устройств...");
			BluetoothDeviceInfo[] devices = cli.DiscoverDevices();
			if (devices.Any())
			{
				SendMessage(string.Format("Найдено {0} bluetooth устройств:", devices.Length));
				foreach (var foundDevice in devices)
					SendMessage(foundDevice.DeviceName);

				device = devices.FirstOrDefault(x => x.DeviceName == DeviceName);
				if (device != null)
				{
					SendMessage("Устройство-метка есть в списке");
					deviceGiud = device.InstalledServices.First();
					Ready = true;
				}
			}
			else
				SendMessage("Bluetooth устройств не обнаружено.");
		}

		public void Search()
		{
			try
			{
				ServiceRecord[] records = device.GetServiceRecords(deviceGiud);
				inRange = true;
			}
			catch (SocketException)
			{
				inRange = false;
			}
		}

		private void SendMessage(string text)
		{
			if (newMessage != null)
				newMessage(text);
		}	
	}
}
