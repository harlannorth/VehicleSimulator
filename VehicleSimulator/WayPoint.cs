﻿using System;
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
	public class WayPoint
	{
		public static implicit operator WayPoint(int i)
		{
			return new WayPoint(i);
		}

		public static implicit operator WayPoint(double i)
		{
			return new WayPoint(i);
		}

		public WayPoint(double milesToNextWayPoint)
		{
			MileToNextWayPoint = milesToNextWayPoint;
		}

		/// <summary>
		/// amount of distance until next waypoint
		/// </summary>
		public double MileToNextWayPoint { set;  get; }
	}
}
