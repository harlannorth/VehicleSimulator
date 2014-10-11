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
			var vehicle = new VehicleSimulator.Vehicle(30, new List<VehicleSimulator.WayPoint>() { new WayPoint(33.833769, -117), new WayPoint(33.82652, -117), new WayPoint(33.833769, -117) });

			//attach listener
			var listen = new Listener(vehicle);


			var factory = new System.Threading.Tasks.TaskFactory();

			//start the vehicle
			var task = factory.StartNew(() => vehicle.Drive());

			//wait 10 seconds
			System.Threading.Thread.Sleep(30000);

			
			vehicle.ChangeSpeed(60);

			//wait for the vehicle to finish
			task.Wait();

			Console.WriteLine(listen.CoordinateLog.Split(" ".ToCharArray()).Where(s => s == "Got").Count());


			//parse the listener's log to get the number of coordinate events that happened
			Assert.IsTrue(listen.CoordinateLog.Split(" ".ToCharArray()).Where(str => str == "Got").Count() == 22);

		}



		/// <summary>
		/// test to make sure the vehicle speed can be changed
		/// </summary>
		[TestMethod]
		[TestCategory("Instant Test")]
		public void CanUpdateVehicleSpeed()
		{
			var simulator = new VehicleSimulator.Vehicle(25, new List<VehicleSimulator.WayPoint>());

			simulator.ChangeSpeed(30);

			Assert.AreEqual(30, simulator.CurrentSpeed);

		}

		/// <summary>
		/// Tests that we are getting the expected results from the Waypoint distance method
		/// </summary>
		[TestMethod]
		[TestCategory("Instant Test")]
		public void GetValidDistance()
		{
	
			var first = new VehicleSimulator.WayPoint(33.833769, -117);
			var second = new VehicleSimulator.WayPoint(33.848219999999735, -117);
			var diff = first.DistanceToNextWayPoint(second);

			Assert.AreEqual(System.Math.Round(diff,3,MidpointRounding.AwayFromZero), .999);

		}


		/// <summary>
		/// test to make sure that the timespace object returns expected object
		/// </summary>
		[TestMethod]
		[TestCategory("Instant Test")]
		public void GetTimeSpans()
		{
			
			for (int i = 0; i <= 75; i++)
			{
				var timeSpan = VehicleSimulator.Vehicle.TimeSpanFactory(i);

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
			var vehicle = new VehicleSimulator.Vehicle(25, new List<VehicleSimulator.WayPoint>() { new WayPoint(33.833769, -117), new WayPoint(33.82652, -117), new WayPoint(33.833769, -117) });

			//attach listener
			var listen = new Listener(vehicle);
			
			//start the vehicle
			vehicle.Drive();

			//parse the listener's log to get the number of coordinate events that happened
			Assert.IsTrue(listen.CoordinateLog.Split(" ".ToCharArray()).Where(s => s == "Got").Count() == 18);
		
		}

		/// <summary>
		/// Tests that the function which calculates how far the vehicle travels at the given mph for the timespan
		/// works correctly
		/// </summary>
		[TestMethod]
		[TestCategory("Instant Test")]
		public void TesttDistanceTravelledFunction()
		{

			var span = new TimeSpan(0,10,0);

			var distance = VehicleSimulator.Vehicle.DistanceTravelled(span, 60);

			Assert.AreEqual(10, distance);


		}

		/// <summary>
		/// Tests that we are getting the expected results from the Waypoint distance method
		/// </summary>
		[TestMethod]
		[TestCategory("Data Generation")]
		public void FindLat()
		{
			double updateLat = 33.833769;
			double diff;

			do
			{

				updateLat = updateLat - .00001;
				var first = new VehicleSimulator.WayPoint(33.833769, -117);
				var second = new VehicleSimulator.WayPoint(updateLat, -117);
				diff = first.DistanceToNextWayPoint(second);


			} while (diff < .5);

			Console.WriteLine("New lat is: " + updateLat);
			//Assert.AreEqual(System.Math.Round(diff, 3, MidpointRounding.AwayFromZero), .999);

		}

	}
}
