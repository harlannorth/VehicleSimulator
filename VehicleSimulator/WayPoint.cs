using System.Device.Location;
using VehicleSimulator.Interfaces;

namespace VehicleSimulator
{
	/// <summary>
	/// represents a waypoint consisting of a Speed the vehicle 
	/// and the miles to the next waypoint
	/// </summary>
	public class WayPoint : IWaypoint
	{
		/// <summary>
		/// Constructor which takes in the longitude and latitude 
		/// </summary>
		/// <param name="latitude">Latitude of the waypoint</param>
		/// <param name="longitude">Longitude of the Waypoint</param>
		public WayPoint(double latitude, double longitude)
		{
			Position = new Coordinate() { Latitude = latitude, Longitude = longitude };
		}

		/// <summary>
		/// Function gets, in miles, the distance between two Waypoints
		/// </summary>
		/// <param name="otherPoint">Point to calculate distance to</param>
		/// <returns>Miles between the waypoints</returns>
		public double DistanceToNextWayPoint(ICoordinate otherPoint)
		{
			//using the system.device GeoCoordinate class calculate the distance
			var thisGeoCoordinate = new GeoCoordinate(Position.Latitude, Position.Longitude);
			var otherGeoCoordinate = new GeoCoordinate(otherPoint.Latitude, otherPoint.Longitude);

			//function does meters, change to miles
			return thisGeoCoordinate.GetDistanceTo(otherGeoCoordinate) / 1609.344;

		}

		/// <summary>
		/// Position of the Waypoint
		/// </summary>
		public ICoordinate Position
		{
			get;
			private set;
		}

	}
}
