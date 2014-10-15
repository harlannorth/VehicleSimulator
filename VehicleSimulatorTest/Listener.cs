using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulator
{
	/// <summary>
	/// Class to subscribe to a vehicles events
	/// </summary>
	public class Listener : VehicleSimulator.ICoordinateListener
	{
		/// <summary>
		/// Takes in a vehicle and listens to the events
		/// </summary>
		/// <param name="vehicle">The simulated vehicle</param>
		public Listener(VehicleSimulator.Vehicle vehicle)
		{
			CoordinateLog = string.Empty;
			_vehicle = vehicle;
			vehicle.NewCoordinate += new EventHandler<ICoordinate>(GotNewCoordinate);
		}

		/// <summary>
		/// A log of the Emissions from the Vehicle
		/// </summary>
		public string CoordinateLog { get; private set; }

		/// <summary>
		/// Backing store for vehicle
		/// </summary>
		private VehicleSimulator.Vehicle _vehicle;

		/// <summary>
		/// Event handler for the emitted data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="coordinates"></param>
		public void GotNewCoordinate(object sender, ICoordinate coordinates)
		{
			CoordinateLog += string.Format("{0} Got Coorindates \\n ", DateTime.UtcNow);
			System.Diagnostics.Debugger.Log(0, "log", string.Format("{0} Got Coorindates \n", DateTime.UtcNow));
		}

		

	}
}
