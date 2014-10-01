using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulator
{
	/// <summary>
	/// represents a waypoint consisting of a Speed the vehicle 
	/// and the miles to the next waypoint
	/// </summary>
	class WayPoint
	{
		public WayPoint(int speed, int milesToNextWayPoint)
		{
			Speed = speed;
			MileToNextWayPoint = milesToNextWayPoint;
		}

		/// <summary>
		/// speed the vehicle is going
		/// </summary>
		public int Speed {  set;  get; }

		/// <summary>
		/// amount of distance until next waypoint
		/// </summary>
		public int MileToNextWayPoint { set;  get; }
	}
}
