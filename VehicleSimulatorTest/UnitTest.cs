using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace VehicleSimulator
{
	[TestClass]
	public class UnitTest
	{


		/// <summary>
		/// Tests starting a sehicle and that 
		/// </summary>
		[TestMethod]
		[TestCategory("Test Takes Time")]
		public void TestRecieveEmissionsAndChangeSpeed()
		{

			//create class
			var vehicle = new VehicleSimulator.EmitPosition(30, new List<VehicleSimulator.WayPoint>() { .5, .5 });

			//attach listener
			var listen = new Listener(vehicle);


			var factory = new System.Threading.Tasks.TaskFactory();

			//start the vehicle
			var task = factory.StartNew(() => vehicle.Control());

			//wait 10 seconds
			System.Threading.Thread.Sleep(30000);

			
			vehicle.ChangeSpeed(60);

			//wait for the vehicle to finish
			task.Wait();

			//parse the listener's log to get the number of coordinate events that happened
			Assert.IsTrue(listen.CoordinateLog.Split(" ".ToCharArray()).Where(str => str == "Got").Count() == 24);

		}



		/// <summary>
		/// test to make sure the vehicle speed can be changed
		/// </summary>
		[TestMethod]
		[TestCategory("Instant Test")]
		public void CanUpdateVehicleSpeed()
		{
			var simulator = new VehicleSimulator.EmitPosition(25, new List<VehicleSimulator.WayPoint>());

			simulator.ChangeSpeed(30);

			Assert.AreEqual(30, simulator.CurrentSpeed);

		}


		/// <summary>
		/// test to make sure that the timespace object returns expected object
		/// </summary>
		[TestMethod]
		[TestCategory("Instant Test")]
		public void GetTimeSpans()
		{
			var simulator = new VehicleSimulator.EmitPosition(25, new List<VehicleSimulator.WayPoint>());

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

		/// <summary>
		/// Tests starting a sehicle and that 
		/// </summary>
		[TestMethod]
		[TestCategory("Test Takes Time")]
		public void TestRecieveEmissions()
		{

			//create class
			var vehicle = new VehicleSimulator.EmitPosition(25, new List<VehicleSimulator.WayPoint>() { .5, .5 });

			//attach listener
			var listen = new Listener(vehicle);
			
			//start the vehicle
			vehicle.Control();

			//parse the listener's log to get the number of coordinate events that happened
			Assert.IsTrue(listen.CoordinateLog.Split(" ".ToCharArray()).Where(s => s == "Got").Count() == 16);
		
		}

		/// <summary>
		/// Tests that the function which calculates how far the vehicle travels at the given mph for the timespan
		/// works correctly
		/// </summary>
		[TestMethod]
		[TestCategory("Instant Test")]
		public void TesttDistanceTravelledFunction()
		{
			var vehicle = new VehicleSimulator.EmitPosition(25, new List<VehicleSimulator.WayPoint>() {5,10});

			var span = new TimeSpan(0,10,0);

			var distance = vehicle.DistanceTravelled(span, 60);

			Assert.AreEqual(10, distance);


		}
	}
}
