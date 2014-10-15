using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulator
{
	/// <summary>
	/// A structure that implements ICoordinate and consists of a latitude and longitude
	/// </summary>
	public struct Coordinate : VehicleSimulator.ICoordinate
	{
		/// <summary>
		/// The Latitude of the Coordinates
		/// </summary>
		public double Latitude { get; set; }

		/// <summary>
		/// The longitude of the coordinates
		/// </summary>
		public double Longitude { get; set; }
	}
}
