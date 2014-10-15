using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulator.Interfaces
{
	/// <summary>
	/// Interface that defines a wayppoint consisting of a function to get the difference in miles between this waypoint and another
	/// and a set of coordinates for the waypoint
	/// </summary>
	public interface IWaypoint
	{
		/// <summary>
		/// Function that gets the distance between this way point another one
		/// </summary>
		/// <param name="otherWaypoint">Waypoint to find the distance to</param>
		/// <returns>the distance in miles to the other point</returns>
		double DistanceToNextWayPoint(ICoordinate otherWaypoint);
		
		/// <summary>
		/// the lat/long of the IWaypoint 
		/// </summary>
		ICoordinate Position { get; }
		
	}
}
