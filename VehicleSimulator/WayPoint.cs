using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSimulator.Interfaces;

namespace VehicleSimulator
{
	/// <summary>
	/// represents a waypoint consisting of a Speed the vehicle 
	/// and the miles to the next waypoint
	/// </summary>
	public class WayPoint : IWaypoint
	{
		//public static implicit operator WayPoint(int lattitude, int longitude)
		//{
		//	return new WayPoint(lattitude, longitude);
		//}

		//public static implicit operator WayPoint(double lattitude, double longitude)
		//{
		//	return new WayPoint(lattitude, longitude);
		//}

		public WayPoint(double lattitude, double longitude)
		{
			_position = new Coordinate() { Latitude = lattitude, Longitude = longitude };
		}

		/// <summary>
		/// amount of distance until next waypoint
		/// </summary>
		public double MileToNextWayPoint { set;  get; }

		public double DistanceToNextWayPoint(IWaypoint otherWaypoint)
		{
			var thisGeoCoordinate = new GeoCoordinate(_position.Latitude, _position.Longitude);
			var otherGeoCoordinate = new GeoCoordinate(otherWaypoint.Position.Latitude, otherWaypoint.Position.Longitude);

			return thisGeoCoordinate.GetDistanceTo(otherGeoCoordinate);

		}

		public ICoordinate Position
		{
			get { return _position; }
		}

		private Coordinate _position;
	}
}
