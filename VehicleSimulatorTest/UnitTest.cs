using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VehicleSimulator
{
	[TestClass]
	public class UnitTest
	{
		/// <summary>
		/// test to make sure that the timespace object returns expected object
		/// </summary>
		[TestMethod]
		public void GetTimeSpans()
		{
			var simulator = new VehicleSimulator.EmitPosition();

			for (int i = 0; i <= 75; i++)
			{
				var timeSpan = simulator.TimeSpanFactory(i);

				int seconds = 0;

				if (i <= 25)
				{
					seconds = 9;
				}
				else if (i <= 50)
				{
					seconds = 6;
				}
				else
				{
					seconds = 3;
				}

				Assert.AreEqual(new TimeSpan(0, 0, seconds), timeSpan);

			}

		}

		[TestMethod]
		public void RecieveEmission()
		{

					//create class
			var vehicle = new VehicleSimulator.EmitPosition();

			//attach listener
			var listen = new Listener(vehicle);

			vehicle.Control(56, new System.Threading.CancellationToken());

		
		}

		public class Listener
		{


			public Listener(VehicleSimulator.EmitPosition vehicle)
			{
				_vehicle = vehicle;
				vehicle.NewCoordinate += new EventHandler<System.Device.Location.GeoCoordinate>(GotNewCoordinate);
			}

			private VehicleSimulator.EmitPosition _vehicle;

			private void GotNewCoordinate(object sender, System.Device.Location.GeoCoordinate coordinates)
			{
					System.Diagnostics.Debugger.Log(0, "log", string.Format("{0} Got Coorindates", DateTime.UtcNow));
			}

		}
	}
}
