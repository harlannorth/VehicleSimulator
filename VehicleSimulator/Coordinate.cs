using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulator
{
	public struct Coordinate : VehicleSimulator.ICoordinate
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
