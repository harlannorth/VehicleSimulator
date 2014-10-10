using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleSimulator.Interfaces
{
	public interface IWaypoint
	{
		double DistanceToNextWayPoint(IWaypoint otherWaypoint);
		ICoordinate Position { get; }
		
	}
}
